        ...
        using (System.IO.StreamReader file = new System.IO.StreamReader(@"E:\file\log.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(DateTime.Now.Date.ToShortDateString()))
                {
                    sb.AppendLine(line);
                    line = file.ReadLine();
                    if(line != null) sb.AppendLine(line);
                    line = file.ReadLine();
                    if(line != null) sb.AppendLine(line);
                }
            }
        }
