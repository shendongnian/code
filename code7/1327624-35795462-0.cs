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
            var deepest = directories.Max(d => d.Length);
        }
