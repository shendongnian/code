    [System.Runtime.InteropServices.DllImport("kernel32")]
    static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);
    [System.Runtime.InteropServices.DllImport("kernel32")]
    static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
...
    StringBuilder temp = new StringBuilder(255);
    GetPrivateProfileString("section", "key", "default", temp, 255, inifilename);
    String value = temp.ToString();
    WritePrivateProfileString("section", "key", value, inifilename);
