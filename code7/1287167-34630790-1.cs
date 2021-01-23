        private static List<string> folders = new List<string>();
        private void buttonExample_Click(object sender, EventArgs e)
        {
            folders.Clear();
            string input = textBox1.Text;
            string currentDir = string.Empty, currentPattern = string.Empty, nextPattern = string.Empty;
            foreach (char c in input)
            {
                if (c == '?')
                {
                    string[] f = input.Split(new[] {'?'}, 2);
                    if (f[0].Length > 0)
                    {
                        currentDir = Directory.GetParent(f[0]).FullName;
                    }
                    if (f[1].Length > 0)
                    {
                        nextPattern = f[1].TrimStart('\\');
                    }
                    string[] w = input.Split('\\');
                    foreach (string s in w)
                    {
                        if (s.Contains('?'))
                        {
                            currentPattern = s;
                            break;
                        }
                    }
                    break;
                }
                else if(c == '*')
                {
                    string[] f = input.Split(new[] { '*' }, 2);
                    if (f[0].Length > 0)
                    {
                        currentDir = Directory.GetParent(f[0]).FullName;
                    }
                    if (f[1].Length > 0)
                    {
                        nextPattern = f[1].TrimStart('\\');
                    }
                    string[] w = input.Split('\\');
                    foreach (string s in w)
                    {
                        if (s.Contains('*'))
                        {
                            currentPattern = s;
                            break;
                        }
                    }
                    break;
                }
            }
            DirectoryInfo di = new DirectoryInfo(currentDir);
            List<string> foldersNew = new List<string>();
            foldersNew = GetAllFolders(di, currentPattern, nextPattern);
        }
        private static List<string> GetAllFolders(DirectoryInfo currentDir,string currentPattern, string nextPatten)
        {
            DirectoryInfo[] dis = currentDir.GetDirectories(currentPattern);
            if (dis.Length == 0 && string.Equals(currentPattern,string.Empty))
                folders.Add(currentDir.FullName);
            if (dis.Length > 0)
            {
                string[] remainPattern = nextPatten.Split("\\".ToCharArray());
                if (remainPattern.Length > 0)
                {
                    foreach (DirectoryInfo di in dis)
                    {
                        GetAllFolders(di, remainPattern.First(),
                                       string.Join("\\", remainPattern.Skip(1).ToArray()));
                    }
                }
            }
            return folders;
        }
