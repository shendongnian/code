        public int ReturnRightCount(out int wrongCount)
        {
            var dbString = "The Quick Brown Fox";
            var inputString = "The Quick Brown Fox Jumps";
            var returnRight = 0;
            wrongCount = 0;
            var WordsFromDatabaseSplit = dbString.Split(' ');
            var EnteredWordsSplit = inputString.Split(' ');
            if (WordsFromDatabaseSplit.Length > EnteredWordsSplit.Length)
            {
                wrongCount = 0;
               return 0;
            }
            for (int i = 0; i < WordsFromDatabaseSplit.Length; i++)
            {
                if (WordsFromDatabaseSplit[i].Equals(EnteredWordsSplit[i],StringComparison.OrdinalIgnoreCase))
                {
                    returnRight ++;
                }
                else
                {
                    wrongCount++;
                }
            }
            return returnRight;
        }
    }
