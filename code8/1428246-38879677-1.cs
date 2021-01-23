    using System.Text.RegularExpressions;
        public Form1()
        {
            InitializeComponent();
            string linetoparse = "[Event Product].[Event Category Filter].[Category Group].&[E].&[F].&[G].&[H]";
            DoIt(linetoparse);
        }
        private void DoIt(string linetoparse)
        {
            string pattern = @"((?<=\[)(.*?)(?=\]))";//the pattern you are looking for
            MatchCollection matches = null;//initialize a variable to hold your matches
            if (Regex.IsMatch(linetoparse, pattern))//If there is at least 1 match
            {
                matches = Regex.Matches(linetoparse, pattern);//store the matches in our storage variable
            }
            if (matches != null)
            {
                string match1 = ((Match)matches[0]).ToString();//Event Product
                string match2 = ((Match)matches[1]).ToString();//Event Category Filter
                string match3 = ((Match)matches[2]).ToString();//Category Group
            }
        }
