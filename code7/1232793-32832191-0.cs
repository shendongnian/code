            string[] input  = {"9.86", "9", "-100", "-95.3"};
            List<int> intNums = new List<int>();
            foreach (string s in input)
            {
                decimal number;
                if (Decimal.TryParse(s, out number))
                {
                    number = number * 10;  
                    intNums.Add((int)number);
                }
            }
