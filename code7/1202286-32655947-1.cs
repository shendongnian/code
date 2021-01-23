    public IEnumerable<FileDetails> EnumerateFiles(string szDriveLetter)
            {
               
                List<FileDetails> fdList = new List<FileDetails>();
                try
                {
                    var usnRecord = default(USN_RECORD);
                    var mft = default(MFT_ENUM_DATA);
                    var dwRetBytes = 0;
                    int cb;
                    var dicFrnLookup = new Dictionary<long, FSNode>();
                    bool bIsFile;
    
                    // This shouldn't be called more than once.
                    if (m_Buffer.ToInt32() != 0)
                    {
                        throw new Exception("invalid buffer");
                    }
    
                    // Assign buffer size
                    m_BufferSize = 65536;
                    //64KB
    
                    // Allocate a buffer to use for reading records.
                    m_Buffer = Marshal.AllocHGlobal(m_BufferSize);
    
                    // correct path
                    szDriveLetter = szDriveLetter.TrimEnd('\\');
    
                    // Open the volume handle 
                    m_hCJ = OpenVolume(szDriveLetter);
                    uint iny = NativeMethods.GetLastError();
                    // Check if the volume handle is valid.
                    if (m_hCJ == INVALID_HANDLE_VALUE)
                    {
                        throw new Exception("Couldn't open handle to the volume.");
                    }
    
                    mft.StartFileReferenceNumber = 0;
                    mft.LowUsn = 0;
                    mft.HighUsn = long.MaxValue;
    
                    do
                    {
                        if (DeviceIoControl(m_hCJ, FSCTL_ENUM_USN_DATA, ref mft, Marshal.SizeOf(mft), m_Buffer, m_BufferSize, ref dwRetBytes, IntPtr.Zero))
                        {
                            cb = dwRetBytes;
                            // Pointer to the first record
                            IntPtr pUsnRecord = new IntPtr(m_Buffer.ToInt32() + 8);
    
                            while ((dwRetBytes > 8))
                            {
                                // Copy pointer to USN_RECORD structure.
                                usnRecord = (USN_RECORD)Marshal.PtrToStructure(pUsnRecord, usnRecord.GetType());
    
                                // The filename within the USN_RECORD.
                                string fileName = Marshal.PtrToStringUni(new IntPtr(pUsnRecord.ToInt32() + usnRecord.FileNameOffset), usnRecord.FileNameLength / 2);
    
                                bIsFile = !usnRecord.FileAttribute.HasFlag(FileAttributes.Directory);
                                dicFrnLookup.Add(usnRecord.FileReferenceNumber, new FSNode(usnRecord.ParentFileReferenceNumber, fileName, bIsFile));
    
                                // Pointer to the next record in the buffer.
                                pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usnRecord.RecordLength);
    
                                dwRetBytes -= usnRecord.RecordLength;
                            }
    
                            // The first 8 bytes is always the start of the next USN.
                            mft.StartFileReferenceNumber = Marshal.ReadInt64(m_Buffer, 0);
    
    
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit Do
    
                        }
    
                    } while (!(cb <= 8));
    
                    // Resolve all paths for Files
                    foreach (FSNode oFSNode in dicFrnLookup.Values.Where(o => o.IsFile))
                    {
                        FileDetails fd = new FileDetails();
                        string sFullPath = oFSNode.FileName;
                        FSNode oParentFSNode = oFSNode;
    
                        while (dicFrnLookup.TryGetValue(oParentFSNode.ParentFRN, out oParentFSNode))
                        {
                            sFullPath = string.Concat(oParentFSNode.FileName, "\\", sFullPath);
                        }
                        sFullPath = string.Concat(szDriveLetter, "\\", sFullPath);
                    
                        //File Attribute details
                        WIN32_FILE_ATTRIBUTE_DATA data;                
    
                        if (NativeMethods.GetFileAttributesEx(@sFullPath, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out data))
                        {
    
                            fd.FileSize = Convert.ToDouble(data.fileSizeLow);
                        }
               
                        long highBits = data.creationTime.dwHighDateTime;
                        highBits = highBits << 32;
    
                        DateTime createdDate = DateTime.FromFileTimeUtc(highBits + (uint)data.creationTime.dwLowDateTime);
                        fd.CreatedDate = createdDate.ToString(CultureInfo.CurrentCulture);
                        fd.CreatedYear = createdDate.Year;
                        fd.FileType = data.filetype;
    
                        long highBitsModified = data.lastWriteTime.dwHighDateTime;
                        highBitsModified = highBitsModified << 32;
                        DateTime modifiedDate = DateTime.FromFileTimeUtc(highBitsModified + (uint)data.creationTime.dwLowDateTime);
                        fd.ModifiedYear = modifiedDate.Year;
                        fd.ModifiedDate = modifiedDate.ToString(CultureInfo.CurrentCulture);
                        fd.FilePath = sFullPath;
                        fd.MachineName = SystemInformation.ComputerName;
    
                        List<string> names = sFullPath.Split('.').ToList();
                        fd.FileType = "." + names.LastOrDefault();                    
    
                        List<string> folders = sFullPath.Split('\\').ToList();
                        //fd.FileName = folders.LastOrDefault();
                        fd.FileName = oFSNode.FileName;
                        fdList.Add(fd);
    
                        yield return fd;
                    }
                }
                finally
                {
                    //// cleanup
                    Cleanup();
                }
            }
    public class NativeMethods
            {
                [DllImport("KERNEL32.dll", CharSet = CharSet.None)]
                public static extern bool GetFileAttributesEx(string path, GET_FILEEX_INFO_LEVELS level, out WIN32_FILE_ATTRIBUTE_DATA data);
    
                [DllImport("kernel32.dll")]
                public static extern uint GetLastError();
    
            }
