    using System.Runtime.InteropServices;
    using System.ComponentModel;
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern bool EncryptFile(string filename);
            
    public static void EnableEncryption(string filename)
    {
        if (!EncryptFile(filename))
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
