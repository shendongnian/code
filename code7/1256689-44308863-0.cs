    static void Main(string[] args)
            {
                CRYPTCATMEMBER ccm = null;
                try
                {
                    PFN_CDF_PARSE_ERROR_CALLBACK pfn = ParseErrorCallback;
                    string s = null; //This null assignment is deliberately done.
    
                    IntPtr cdfPtr = CryptCATCDFOpen("catalog.cdf", Marshal.GetFunctionPointerForDelegate(pfn));
                    CRYPTCATCDF cdf = (CRYPTCATCDF) Marshal.PtrToStructure(cdfPtr, typeof(CRYPTCATCDF)); //This call is required else the catlog file creation fails
    
                    ccm = new CRYPTCATMEMBER
                    {
                        pIndirectData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SIP_INDIRECT_DATA)))
                    };
    
                    do
                    {
                        s = CryptCATCDFEnumMembersByCDFTagEx(cdfPtr, s, Marshal.GetFunctionPointerForDelegate(pfn), ccm, true, IntPtr.Zero);
                        Console.WriteLine(s ?? "N/A");
                    } while (s != null);
                    CryptCATCDFClose(cdfPtr); //This is required to update the .cat with the files details specified in .cdf file.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    // Free the unmanaged memory.
                    if (ccm != null)
                    {
                        Marshal.FreeHGlobal(ccm.pIndirectData);
                    }
                }
            }
