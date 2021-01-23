    class FileReader // Actually, it is a useless class, get rid of it
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
