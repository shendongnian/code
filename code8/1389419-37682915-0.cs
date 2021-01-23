     public string GetPalindrom()
        {
            string strInput = "aaab";
            string strDistinct = new String(strInput.Distinct().ToArray());
            int intOccurence = 0;
            string outputString = string.Empty;
            for (int i = 0; i < strDistinct.Length; i++)
            {
                intOccurence = 0;
                foreach (var item in strInput)
                {
                    if (item == strDistinct[i])
                        intOccurence++;
                }
                if (intOccurence == 1)
                {
                    outputString = strInput.Remove(strInput.IndexOf(strDistinct[i]),1);
                    break;
                }
            }
            return outputString;
        }
