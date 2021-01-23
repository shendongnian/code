       public string GetFullCombineNonRecur()
        {
            var sb = new StringBuilder();
            var gemStack = new Stack<Gem>();
            Gem gem = this;
            int level = 0;
            while (true)
            {
                while (!gem.IsBaseGem)
                {
                    sb.Append('('); level++;
                    gemStack.Push(gem);
                    gem = gem.Component1;
                }
    
                sb.Append(gem.ID);
    
                do
                {
                    if (level == 0)
                    {
                        if (gem != this) { sb.Remove(0, 1).Remove(sb.Length - 1, 1); }
                        return sb.ToString();
                    }
                    gem = gemStack.Pop();
                    if (gem == null) // is ")" mark
                    {
                        sb.Append(')'); level--;
                    }
                } while (gem == null);
    
                sb.Append('+');
                gemStack.Push(null); // push ")" mark here
                gem = gem.Component2;
            }
        }
