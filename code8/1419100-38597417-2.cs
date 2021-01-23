            Regex reg = new Regex(@"([A-Za-z].*)", RegexOptions.Singleline);
            // Split the string on line breaks, removing parts consisted of only numbers
            // ... The return value from Split is a string array.
            string[] lines = Regex.Split(Regex.Replace(value, @"(?<=\n)(.[\d]*)(?=\r)|(?<=\n)(.[\d]*)(?=$)|(?<=^)(.[\d]*)(?=\r)", string.Empty), "\r\n");
            //Removing empty spaces with Linq
            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray(); 
            for (int i = 0; i < lines.Count(); i++) 
            {
                Match m = reg.Match(lines[i]);
                if (m.Success)
                {
                    lines[i] = m.Value;
                }
                Console.WriteLine(lines[i]);
            }
        }
