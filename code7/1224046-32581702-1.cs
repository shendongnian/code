    public static Dictionary<int,int> GetPair(List<Token> data)
    {
        Stack<Token> stacken = new Stack<Token>();
        var pair = new Dictionary<int, int>();
        Token temp = new Token();
        foreach (char A in data)
        {
             if (item.TokenValue == "(" )
             {
                  stacken.Push(A);
             }
             if (item.TokenValue == ")" )
             {
                 if (stacken.Last() == '(')
                 {
                      temp = stacken.Pop();
                      pair.Add(temp.TokenID,item.TokenID)
                 }
                 else
                 {
                      stacken.Push(A);
                 }
             }
        }
        return pair; 
    }         
