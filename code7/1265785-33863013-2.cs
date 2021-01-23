     public string GetFullCombineNonRecur()
        {
            var sb = new StringBuilder();
            var gemStack = new Stack<Gem>();
            Gem gem = this;
            while (gem != null)
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
                    if (!gemStack.Any()) { gem = null; break; }
                    gem = gemStack.Pop();
                    if (gem == null) // is ")" mark
                    {
                        sb.Append(')');
                    }
                    else
                    {
                        sb.Append('+');
                        if (gem != this) // outermost parentheses
                        {
                            gemStack.Push(null); // push ")" mark here
                        }
                        gem = gem.Component2;
                    }
                } while (gem == null);
            }
    
            return sb.ToString();
        }
