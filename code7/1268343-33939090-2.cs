    static void WriteDirectories(string path, int level = 0)
    {
        string[] dirs = Directory.GetDirectories(path);
        for (int i = 0; i < dirs.Length; i++)
        {
            for (int j = 0; j < level; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(dirs[i]);
            WriteDirectories(dirs[i], (level + 1));
        }
    }
