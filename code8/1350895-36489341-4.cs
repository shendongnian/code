        public static string Replace2(string input)
        {
            //An array of char to check the input
            char[] inputCharArr = input.ToCharArray();
            input = "";
            foreach (var c in inputCharArr)
            {
                //If the digit was a number ([0-9] are [48-57] in unicode),
                //replace the old char with the new char
                //(8272 when added to the unicode of [0-9] gives the desired result)
                int intC = (int)c;
                if (intC > 47 && intC < 58)
                    input += (char)(intC + 8272);
                else input += c; //If it wasn't a digit, add c as it is
            }
            return input;
        }
