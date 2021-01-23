           static void WriteDirectories(string path, int depth) {
                string[] dirs = Directory.GetDirectories(path);
                for(int i = 0; i < dirs.Length; i++) {
                     string preSpaces = new String(' ',depth);
                     Console.WriteLine(preSpaces + dirs[i]); 
                     WriteDirectories(dirs[i], depth+1);
                }
           }
