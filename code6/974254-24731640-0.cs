            public static bool IsWellFormed(string path)
            {
                string path = "C:\\windows\\:ppz";
                var isRooted = Path.IsPathRooted(path);
                var root = Path.GetPathRoot(path);
                var list = path.Split(new char[] {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);            
                for (int i = 0; i < list.Length; i ++)
                {
                    if(i == 0 && isRooted && s[i]+"\\" == root) continue;
                    if (s[i].Intersect(Path.GetInvalidPathChars()).Count() != 0)
                        return false;
                    if (s[i].Intersect(Path.GetInvalidFileNameChars()).Count() != 0)
                        return false;
                }
                return true;
            }
