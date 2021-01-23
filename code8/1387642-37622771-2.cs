cs
public static FileInfo GetStartUpProject(FileInfo solutionFile)
{
    FileInfo startUpProject = null;
    string projectName = Path.GetFileNameWithoutExtension(solutionFile.FullName);
    FileInfo suoFileInfo = new FileInfo(Path.Combine(solutionFile.Directory.FullName, string.Format(projectName + "{0}", ".suo")));
    
    string guid = ReadStartupOptions(suoFileInfo.FullName).ToString();
    if (!string.IsNullOrEmpty(guid))
    {
        string projectname = GetProjectNameFromGuid(solutionFile, guid).Trim().TrimStart('\"').TrimEnd('\"');
        startUpProject = new FileInfo(Path.Combine(solutionFile.DirectoryName, projectname));
    }
    
    return startUpProject;
}
public static string GetProjectNameFromGuid(FileInfo solutionFile, string guid)
{
    string projectName = null;
    using (var reader = new StreamReader(solutionFile.FullName))
    {
        string line;
        bool found = false;
        while ((line = reader.ReadLine()) != null && !found)
        {
            
            if ((line.IndexOf(guid.ToUpper()) > -1) && line.Contains(",") && line.Contains("="))
            {
                projectName = line.Split(',')[1].Split(',')[0];
                found = true;
            }
        }
    }
    return projectName;
}
//  from https://stackoverflow.com/questions/8817693/how-do-i-programmatically-find-out-the-action-of-each-startup-project-in-a-solut
public static Guid ReadStartupOptions(string filePath)
{
    Guid guid = new Guid();
    if (filePath == null)
    {
        throw new InvalidOperationException("No file selected");
    }
    const string token = "StartupProject\0=&\0";
    byte[] tokenBytes = Encoding.Unicode.GetBytes(token);
    
    byte[] bytes;
    using (var stream = new MemoryStream())
    {
        ExtractStream(filePath, "SolutionConfiguration", stream);
        bytes = stream.ToArray();
    }
    
    var guidBytes = new byte[36 * 2]; 
    for (int i2 = 0; i2 < bytes.Length; i2++)
    {
        if (bytes.Skip(i2).Take(tokenBytes.Length).SequenceEqual(tokenBytes))
        {
            Array.Copy(bytes, i2 + tokenBytes.Length + 2, guidBytes, 0, guidBytes.Length);
         
            guid = new Guid(Encoding.Unicode.GetString(guidBytes));
            break;
        }
    }
    return guid;
}
public static void ExtractStream(string filePath, string streamName, Stream output)
{
    if (filePath == null)
        throw new ArgumentNullException("filePath");
    if (streamName == null)
        throw new ArgumentNullException("streamName");
    if (output == null)
        throw new ArgumentNullException("output");
    IStorage storage;
    int hr = StgOpenStorage(filePath, null, STGM.READ | STGM.SHARE_DENY_WRITE, IntPtr.Zero, 0, out storage);
    if (hr != 0)
        throw new Win32Exception(hr);
    try
    {
        IStream stream;
        hr = storage.OpenStream(streamName, IntPtr.Zero, STGM.READ | STGM.SHARE_EXCLUSIVE, 0, out stream);
        if (hr != 0)
            throw new Win32Exception(hr);
        int read = 0;
        IntPtr readPtr = Marshal.AllocHGlobal(Marshal.SizeOf(read));
        try
        {
            var bytes = new byte[0x1000];
            do
            {
                stream.Read(bytes, bytes.Length, readPtr);
                read = Marshal.ReadInt32(readPtr);
                if (read == 0)
                    break;
                output.Write(bytes, 0, read);
            } while (true);
        }
        finally
        {
            Marshal.FreeHGlobal(readPtr);
            Marshal.ReleaseComObject(stream);
        }
    }
    finally
    {
        Marshal.ReleaseComObject(storage);
    }
}
[DllImport("ole32.dll")]
private static extern int StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
                                         IStorage pstgPriority, STGM grfMode, IntPtr snbExclude, uint reserved,
                                         out IStorage ppstgOpen);
#region Nested type: IStorage
[ComImport, Guid("0000000b-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
private interface IStorage
{
    void Unimplemented0();
    [PreserveSig]
    int OpenStream([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, IntPtr reserved1, STGM grfMode,
                   uint reserved2, out IStream ppstm);
    // other methods not declared for simplicity
}
#endregion
#region Nested type: STGM
[Flags]
private enum STGM
{
    READ = 0x00000000,
    SHARE_DENY_WRITE = 0x00000020,
    SHARE_EXCLUSIVE = 0x00000010,
    // other values not declared for simplicity
}
#endregion    
