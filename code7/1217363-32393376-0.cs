            StringBuilder builder = new StringBuilder(line);
            foreach (Match m in Regex.Matches(builder.ToString(), "\".*?\""))
            {
                if (m.Value.Contains(";"))      // If it contains a semicolon
                {
                    string temp = m.Value.Replace(";", "");
                    builder.Replace(m.Value, temp);
                }
            }
            var parts = builder.ToString().Split(new char[] { ';' });
