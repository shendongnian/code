    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);
    
    static string[] chrs = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    
    private static void start(string subName)
    {
        Parallel.For(0, chrs.Length, a =>
        {
            createFolder(Path.Combine(subName, chrs[a]));
        });
    }
    
    private static void createFolder(string path)
    {
        CreateDirectory(path, IntPtr.Zero);
        for (int b = 0; b < chrs.Length; b++)
        {
            string pathB = path + "\\" + chrs[b];
            CreateDirectory(pathB, IntPtr.Zero);
            for (int c = 0; c < chrs.Length; c++)
            {
                string pathC = pathB + "\\" + chrs[c];
                CreateDirectory(pathC, IntPtr.Zero);
                for (int d = 0; d < chrs.Length; d++)
                {
                    string pathD = pathC + "\\" + chrs[d];
                    CreateDirectory(pathD, IntPtr.Zero);
                    Extract("Folder_Generator", pathD, "myFolder", "troll.png");
                }
            }
            Console.WriteLine(path + "\\" + chrs[b]);
        }
    }
