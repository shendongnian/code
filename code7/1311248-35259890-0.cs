    public void CheckParentheses(string inputParentheses)
    {
        // Level counter
        int parenLevel = 0;
        for (int i = 0; i < inputParentheses.Length; i++)
        {
            // Open always good, increment the level
            if (inputParentheses[i] == '(')
                parenLevel++;
            else if (inputParentheses[i] == ')')
                parenLevel--;
    
            // Closing good, but only if the level doesn't drop under zero
            if (parenLevel < 0)
            {
                Console.WriteLine("false");
                return;
            }
        }
        // At the end of the loop, the level should always be zero
        if(parenLevel != 0)
            Console.WriteLine("false");
        else
            Console.WriteLine("true");
    }
