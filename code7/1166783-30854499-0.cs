            string paragraph = String.Empty;
            foreach (var row in File.ReadAllLines("s.txt").Where(row => row != String.Empty))
            {
                if (!row.Contains('~'))
                {
                    dict[paragraph] += " " + row.Trim();
                    continue;
                }
                dict.Add(row.Split('~')[0], string.Join("~", row.Split('~').Skip(1).ToArray()));
                paragraph = row.Split('~')[0];
            }
