        private static int AddTwoStrings(string one, string two) 
        {
            int iOne = 0;
            int iTwo = 0;
            bool successParseOne = Int32.TryParse(one, out iOne);
            bool successParseTwo = Int32.TryParse(two, out iTwo);
            if (!successParseOne) 
            {
                throw new ArgumentException("one");
            }
            else if(!successParseTwo)
            {
                throw new ArgumentException("two");
            }
            return (iOne + iTwo);
        }
