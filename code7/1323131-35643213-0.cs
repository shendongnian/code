    var inputString = txtIntegers.Text;
            List<int> integres = new List<int>();
            if (!String.IsNullOrEmpty(inputString))
            {
                char[] inputChars = inputString.ToCharArray();
                int output = 0;
                foreach(char inputchar in inputChars)
                {
                   bool conversionSuccess = int.TryParse(inputchar.ToString(), out output);
                   if (conversionSuccess)
                   {
                       integres.Add(output);
                       output = 0;
                   }
                }
            }
