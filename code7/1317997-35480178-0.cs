    public static IEnumerable<string> GetFiles(string root, string searchPattern)
    {
        Stack<string> pending = new Stack<string>();
        pending.Push(root);
        while (pending.Count != 0)
        {
            var path = pending.Pop();
            string[] next = null;
            try
            {
                next = Directory.GetFiles(path, searchPattern);                    
            }
            catch { }
            if(next != null && next.Length != 0)
                foreach (var file in next) yield return file;
            try
            {
                next = Directory.GetDirectories(path);
                foreach (var subdir in next) pending.Push(subdir);
            }
            catch { }
        }
    }
