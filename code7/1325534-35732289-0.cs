        public static string PopFrontPadded(ref string oStr, int iPadding)
        {
            // Argument check
            if (iPadding <= 0)
                throw new ArgumentException("iPadding <= 0");
            // Handle idiots
            if (oStr == null)
                return "".PadRight(iPadding);
            // Pop front & pad
            string oRes = new string(oStr.Take(Math.Min(oStr.Length, iPadding)).ToArray());
            oStr = oStr.Substring(oRes.Length);
            return oRes.PadRight(iPadding);
        }
        
        public static string format(string oSeparator, string oNewLine, string[] oStrings, int[] oWidths)
        {
            // Null checks
            if (oStrings == null || oWidths == null || oSeparator == null || oNewLine == null)
                throw new ArgumentException("oStrings == null || oWidths == null || oSeparator == null || oNewLine == null");
            // Length check: Must be same amount of widths as there are strings
            if (oStrings.Length != oWidths.Length)
                throw new ArgumentException("oStrings.Length != oWidths.Length");
            // All widths must be > 0
            foreach (int i in oWidths)
            {
                if (i <= 0)
                    throw new ArgumentException("width must be > 0");
            }
            var sb = new System.Text.StringBuilder();
            List<string> oList = new List<string>(oStrings);
            // Loop while oList contains even one string with length > 0
            do
            {
                // For all given strings
                for (int i = 0; i < oList.Count; i++)
                {
                    
                    // PopFrontPadded
                    string oTmp = oList[i];
                    sb.Append(PopFrontPadded(ref oTmp, oWidths[i]));
                    oList[i] = oTmp;
                    // Append separator
                    if (i < oList.Count - 1)
                        sb.Append(oSeparator);
                }
               
                // Append New Line
                sb.Append(oNewLine);
            } 
            while (oList.Find(x => x.Length > 0) != null); 
            return sb.ToString();
        }
        [STAThread]
        static void Main()
        {
            string text10 = "abcdefghij";
            string text15 = "123456789012345";
            string text6 = "zxywvu";
            string oResult = format(
                " ",                                      // Separator
                Environment.NewLine,                      // Line break
                new string[3] { text10, text15, text6 },  // strings
                new int[3]    {      4,     10,     5 }); // column widths
            Console.WriteLine(oResult);
            /* Outputs 
             *
             * abcd 1234567890 zxywv
             * efgh 12345      u    
             * ij                                
             *
             */
        }
