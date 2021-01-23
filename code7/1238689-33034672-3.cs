        static string[] GetProperties(string dirty)
        {
            List<string> properties = new List<string>();
            int i = dirty.IndexOf("{ ");
            StringBuilder sb = new StringBuilder();
            int propEndIndex = -1; int i2 = -1;
            for (; i != -1; i = dirty.IndexOf("{ ", i + 1))
            {
                i2 = i - 1;
                for (; dirty[i2] == ' '; i2--) { }
                if (dirty[i2] == '(' || dirty[i2] == ')') continue;
                propEndIndex = i2 + 1;
                for (; dirty[i2] != ' '; i2--) { }                
                
                for (i2++; i2 < propEndIndex; i2++)
                    sb.Append(dirty[i2]);                
                properties.Add(sb.ToString());
                sb.Clear();
            }
            return properties.ToArray();
        }
