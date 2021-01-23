      private static string FormatIntString(string input)
        {
            if (input.IndexOf('.') != input.LastIndexOf('.')) 
            {
                if (input.Contains(","))
                {
                    //this case-> Ava.bytes -> 147.258.369,5 =>147258369.5
                    return DoFormat(input.Replace(".", "").Replace(',', '.'));
                }
                else
                {
                    // this case->  Ava.bytes -> 147.258.369 => 147258369.0
                    return DoFormat(input.Replace(".", ""));                   
                }
            }
            else
            {
                if (input.Contains('.'))
                {
                    //this case -> Ava.bytes -> 147,258,369.5 =>147258369.5
                    return DoFormat(input.Replace(",", ""));                   
                }
                else
                {
                    //this case -> Ava.bytes -> 147,258,369 => 147258369.0
                    return DoFormat(input.Replace(",", ""));
                }
            }
        }
        public static string DoFormat(string myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);
            if (s[s.Length-2] != '.')            
                return (myNumber + ".0");            
            else            
                return s;            
        }
