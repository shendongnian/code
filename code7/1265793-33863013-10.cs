    public string GetFullCombineNonRecur()
    {
        var sb = new StringBuilder();
        var gemStack = new Stack<Gem>();
        Gem gem = this;
        while (true)
        {
            while (!gem.IsBaseGem)
            {
                if (gem != this) // outermost parentheses
                {
                    sb.Append('(');
                }
                gemStack.Push(gem);
                gem = gem.Component1;
            }
    
            sb.Append(gem.ID);
    
            do
            {
                if (!gemStack.Any()) { return sb.ToString(); }
                gem = gemStack.Pop();
                if (gem == null) // is ")" mark
                {
                    sb.Append(')');
                }
            } while (gem == null);
    
            sb.Append('+');
            if (gem != this) // outermost parentheses
            {
                gemStack.Push(null); // push ")" mark here
            }
            gem = gem.Component2;
        }
    }
     
