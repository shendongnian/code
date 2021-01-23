    public class CompanyNameComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            var src1 = FormatString(x);
            var src2 = FormatString(y);
            if (src1 == src2)
            {
                return true;
            }
            var difference = CalcLevenshteinDistance(src1, src2);
            // arbitrary number you will need to find what works
            return difference < 7;
        }
        private string FormatString(string source)
        {
            return source.Trim().ToUpper();
        }
        // code taken from http://stackoverflow.com/a/9453762/1798889
        private int CalcLevenshteinDistance(string a, string b)
        {
           // code not included 
        }
        public int GetHashCode(string obj)
        {
            return Soundex(obj).GetHashCode();
        }
        private string Soundex(string data)
        {
            // code not included 
        }
    }
 
