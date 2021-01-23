    [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetDllDirectory(string lpPathName);
    
    //...
    string text4 = Path.Combine(text, "SQLite.Interop.dll");
                    if (!File.Exists(text4))
                    {
                        byte[] array3 = LoadCompressedDllFromResource("nativedll.SQLite.Interop.z");
                        array3 = DecompressBytes(array3);
                        SaveToFile(array3, text4);
                    }
    //...
