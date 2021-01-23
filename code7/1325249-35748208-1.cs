    public static class Extensions
    {
        public static Run GetMultiLineRun(this Run run, string s)
        {
            string[] lines = 
               s.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
            {
                //Don't add break after last line!
                foreach (string line in lines.Reverse().Skip(1).Reverse())
                {
                    run.AppendChild(new Text(line));
                    run.AppendChild(new Break());
                }
                run.AppendChild(new Text(lines.Last()));
            }
            return run;
        }
    }
