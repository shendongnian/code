<!-- -->
    [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    private static extern bool WritePrinter (SafeHandles.PrinterSafeHandle hPrinter, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pBuf, int cdBuf, out int pcWritten);
    
    [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    private static extern bool WritePrinter (SafeHandles.PrinterSafeHandle hPrinter, IntPtr pBuf, int cdBuf, out int pcWritten);
    [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    private static extern int StartDocPrinter(SafeHandles.PrinterSafeHandle hPrinter, int Level, [In] ref DOC_INFO_1 pDocInfo);
    [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    private static extern bool EndDocPrinter (SafeHandles.PrinterSafeHandle hPrinter);
    [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    private static extern bool SetJob (SafeHandles.PrinterSafeHandle hPrinter, int JobID, int Level, IntPtr pJob, int Command);
    private const int JOB_CONTROL_PAUSE = 1;
    private const int JOB_CONTROL_DELETE = 5;
    [StructLayout(LayoutKind.Sequential)]
    private struct DOC_INFO_1
    {
        [MarshalAs(UnmanagedType.LPTStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPTStr)] public string pOutputFile;
        [MarshalAs(UnmanagedType.LPTStr)] public string pDatatype;
    }
    public static int SendPrinterCommand(string PrinterName, string DocumentName, string Command, bool Suspended = false)
    {
        return SendPrinterCommand(null, PrinterName, DocumentName, Command, Suspended);
    }
    public static int SendPrinterCommand(string PrinterName, string DocumentName, string Command, System.Text.Encoding Encoding, bool Suspended = false)
    {
        return SendPrinterCommand(null, PrinterName, DocumentName, Command, Encoding, Suspended);
    }
    public static int SendPrinterCommand(string PrinterName, string DocumentName, byte[] Command, bool Suspended = false)
    {
        return SendPrinterCommand(null, PrinterName, DocumentName, Command, Suspended);
    }
    public static int SendPrinterCommand(string ServerName, string PrinterName, string DocumentName, string Command, bool Suspended = false) 
    {
        return SendPrinterCommand(ServerName, PrinterName, DocumentName, Command, System.Text.Encoding.ASCII, Suspended);
    }
    public static int SendPrinterCommand(string ServerName, string PrinterName, string DocumentName, string Command, System.Text.Encoding Encoding, bool Suspended = false)
    {
        return SendPrinterCommand(ServerName, PrinterName, DocumentName, Encoding.GetBytes(Command), Suspended);
    }
    public static int SendPrinterCommand(string ServerName, string PrinterName, string DocumentName, byte[] Command, bool Suspended = false)
    {
        string FullPrinterPath = string.IsNullOrEmpty(ServerName) ? PrinterName : System.IO.Path.Combine(ServerName, PrinterName);
        using (var h = new SafeHandles.PrinterSafeHandle(FullPrinterPath))
        {
            var di1 = new DOC_INFO_1()
            {
                pDocName = DocumentName,
                pOutputFile = null,
                pDatatype = "RAW"
            };
            int job_id = StartDocPrinter(h, 1, ref di1);
            if (job_id == 0)
            {
                throw new System.ComponentModel.Win32Exception();
            }
            if (Suspended)
            {
                if (!SetJob(h, job_id, 0, IntPtr.Zero, JOB_CONTROL_PAUSE))
                {
                    throw new System.ComponentModel.Win32Exception();
                }
            }
            try
            {
                int total_bytes_written = 0;
                if (!WritePrinter(h, Command, Command.Length, out total_bytes_written))
                {
                    throw new System.ComponentModel.Win32Exception();
                }
                if (total_bytes_written < Command.Length)
                {
                    var gch = GCHandle.Alloc(Command, GCHandleType.Pinned);
                    try
                    {
                        do
                        {
                            int next_index = total_bytes_written;
                            int next_requred_len = Command.Length - next_index;
                            int bytes_written_this_time = 0;
                            if (!WritePrinter(h, Marshal.UnsafeAddrOfPinnedArrayElement(Command, next_index), next_requred_len, out bytes_written_this_time))
                            {
                                throw new System.ComponentModel.Win32Exception();
                            }
                            total_bytes_written += bytes_written_this_time;
                        } while (total_bytes_written < Command.Length);
                    }
                    finally
                    {
                        gch.Free();
                    }
                }
            }
            catch
            {
                SetJob(h, job_id, 0, IntPtr.Zero, JOB_CONTROL_DELETE);
                throw;
            }
            finally
            {
                EndDocPrinter(h);
            }
            return job_id;
        }
    }
