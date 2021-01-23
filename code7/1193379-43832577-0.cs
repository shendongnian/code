      public static bool IsBalanced(string input)
        {
            int numOpen = 0;
            while(input != "")
            {
                char c = input[0];
                input = input.Substring(1);
                numOpen = c == '(' ? (numOpen + 1) : (c == ')' ? (numOpen - 1) : numOpen);
            }
            return numOpen == 0;
        }
