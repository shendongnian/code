        static string[] ClearValues(string[] dirtyLines)
        {            
            string[] result = new string[dirtyLines.Length];
            bool ignore = false; StringBuilder s = new StringBuilder();
            for (int i = 0; i < dirtyLines.Length; i++)
            {                
                for (int i2 = 0; i2 < dirtyLines[i].Length; i2++)
                {
                    if (dirtyLines[i][i2] == '{' || dirtyLines[i][i2] == '}') { s.Append(dirtyLines[i][i2]); ignore = !ignore; continue; }
                    if (!ignore) s.Append(dirtyLines[i][i2]);
                }
                result[i] = s.ToString();
                s.Clear();
            }
            return result;
        }
