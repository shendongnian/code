        static string[] ClearValues(string[] dirtyLines, string[] ignoreValuesList)
        {            
            string[] result = new string[dirtyLines.Length];
            bool ignore = false; StringBuilder s = new StringBuilder();
            StringBuilder s2 = new StringBuilder();            
            
            for (int i = 0; i < dirtyLines.Length; i++)
            {                
                for (int i2 = 0; i2 < dirtyLines[i].Length; i2++)
                {
                    if (dirtyLines[i][i2] == '{') { s2.Clear(); s.Append(dirtyLines[i][i2]); ignore = true; continue; }
                    if (dirtyLines[i][i2] == '}') { if(ignoreValuesList.Contains(s2.ToString())) s.Append(s2.ToString()); s.Append(dirtyLines[i][i2]); ignore = false; continue; }
                    if (!ignore) { s.Append(dirtyLines[i][i2]); } else { s2.Append(dirtyLines[i][i2]); }                    
                }
                result[i] = s.ToString();
                s.Clear();                
            }
            return result;
        }
