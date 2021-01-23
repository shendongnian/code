    using (Privilege p = new Privilege(Privilege.Backup))
    {
        foreach (string path in Directory.GetFileSystemEntries(@"c:\documents and settings"))
        {
            Console.WriteLine(path);
        }
    }
