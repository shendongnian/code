        using (System.IO.StreamReader file = new System.IO.StreamReader(@"E:\file\log.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(DateTime.Now.Date.ToShortDateString()))
                {
                    // This will remove the previous data and keep 
                    // just the last three lines.....
                    sb.Length = 0;
                    sb.AppendLine(line);
                    line = file.ReadLine();
                    if(line != null) sb.AppendLine(line);
                    line = file.ReadLine();
                    if(line != null) sb.AppendLine(line);
                }
            }
        }
