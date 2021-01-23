        public static string[] SplitBitforBit(string text, int bitforbit)
        {
            int splitcount = Convert.ToInt32(RoundAt(text.Length / bitforbit, 0, 0));
            char[] allChars = text.ToCharArray();
            string[] splitted = new string[splitcount];
            int iL = 0;
            for (int i = 0; i != splitted.Length; i++)
            {
                splitted[i] = null;
                for (int j = 0; j != bitforbit; j++)
                {
                    splitted[i] += allChars[iL];
                    iL++;
                }
            }
            return splitted;
        }
