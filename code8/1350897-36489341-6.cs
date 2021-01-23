        public static string Replace(string input)
        {
            char[] inputCharArr = input.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (var c in inputCharArr)
            {
                int intC = (int)c;
                //If the digit was a number ([0-9] are [48-57] in unicode),
                //replace the old char with the new char
                //(8272 when added to the unicode of [0-9] gives the desired result)
                if (intC > 47 && intC < 58)
                    sb.Append((char)(intC + 8272));
                else sb.Append(c);
            }
            return sb.ToString();
        }
