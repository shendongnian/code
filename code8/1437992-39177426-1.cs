    public void testTruncate()
        {
            
            for (int i = 3; i < 1000; i++)
            {
                string testNumber = "";
                if (Math.Log10(Math.Pow(10, i)) > 9)
                {
                    testNumber = (Math.Pow(10, i) / Math.Pow(10, i - 9) - 1).ToString();
                    for (int d = 0; d < Math.Log10(Math.Pow(10, i)) - testNumber.Length; d++)
                    {
                        testNumber += "0";
                    }
                    if (double.Parse(testNumber) > double.MaxValue)
                    {
                        break;
                    }
                }
                else
                {
                     testNumber = (Math.Pow(10, i) - 1).ToString();
                }
              Console.WriteLine(testNumber+" truncated to "+  doTruncate(testNumber, 3, true).ToString("N0")+"\n");
            }
        }
        public double doTruncate(string bigNumString, double numberOfDigitsToTruncateTo, bool addZeroesBack)
        {
            if (bigNumString.Length <= numberOfDigitsToTruncateTo)
            {
                return double.Parse(bigNumString);
            }
            string ret = bigNumString.Substring(0,(int)numberOfDigitsToTruncateTo);
            if (addZeroesBack)
            {
                for (int i = 0; i < bigNumString.Length - numberOfDigitsToTruncateTo; i++)
                {
                    ret += "0";
                }
            }
            double answer = double.Parse(ret);
            if (answer > double.MaxValue)
            {
                return -1;//value too large 
            }
            return answer;
           
        }
