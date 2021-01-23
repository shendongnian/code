        static string[] MySplit(string dirty, char delimiter = ',', string ignoreInside = "()")
        {            
            StringBuilder sb = new StringBuilder();
            bool sectionStarted = false;
            List<string> result = new List<string>();
            for (int i = 0; i < dirty.Length; i++)
            {
                if (!sectionStarted && dirty[i] == delimiter) 
                {
                    result.Add(sb.ToString());
                    sb.Clear(); continue; 
                }
                if (ignoreInside.Contains(dirty[i])) sectionStarted = dirty[i] == ignoreInside[0];                 
                sb.Append(dirty[i]);
            }
            return result.ToArray();
        }
