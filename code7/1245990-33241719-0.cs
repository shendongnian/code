    private static void morseThis(string message)
    {
        char[] messageComponents = message.ToCharArray();
        
        foreach(char c in messageComponents)
        {
            Action[] actions;
          
            if (morseDictionary.TryGetValue(c, out actions))
            {
                foreach(Action action in actions)
                {
                  action();
                }
            }
        }
    }
