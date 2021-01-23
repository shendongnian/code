    using this method pick last 50 lines from file and display to front end    
    
    public static IList<string> GetLog(string logname, string numrows)
        {
            int lineCnt = 1;
            List<string> lines = new List<string>();
            int maxLines;
        
            if (!int.TryParse(numrows, out maxLines))
            {
                maxLines = 50;
            }
        
            string logFile = HttpContext.Current.Server.MapPath("~/" + logname);
        
            BackwardReader br = new BackwardReader(logFile);
            while (!br.SOF)
            {
                string line = br.Readline();
                lines.Add(line + System.Environment.NewLine);
                if (lineCnt == maxLines) break;
                lineCnt++;
            }
            lines.Reverse();
            return lines;
        }
