    static List<string> directories = new List<string>();
            static void GetDirectories(string path)
            {
                try
                {
                    foreach (var directory in Directory.GetDirectories(path))
                    {
                        var di = new DirectoryInfo(directory);
                        directories.Add(di.FullName);
                        GetDirectories(di.FullName);
                    }
                }
                catch (UnauthorizedAccessException uaex) { }
                catch (PathTooLongException ptlex) { }
                catch (Exception ex) { }
            }
    static void Main(string[] args)
        {
            var path = @"C:\";
            GetDirectories(path);
            var maxLevel = directories.Max(d => d.Split('\\').Count());
            var deepest = directories.Select(d => new
                {
                    Path = d,
                    Levels = d.Split('\\').Count()
                })
            .OrderByDescending(d => d.Levels)
            .First();
        }
