    static IEnumerable<string> SplitStringMyWay(string text, char delimitter)
    {
      string[] internalItems = test.Split(delimitter);
      List<string> theItems = new List<string>
      
      string newItem = string.Empty;
      int openParenthesis = 0;
      
      foreach( string item in internalItems )
      {
        newItem += item;
        if (item.Contains("("))
        {
          openParenthesis++;
        }
        if (item.Contains(")"))
        {
          openParenthesis--;
        }
        
        if (openParenthesis == 0)
        {
          theItems.Add(newItem)
          newItem=string.Empty;
        }
      }
    }
