    Stack myStak = new Stack();
        public bool IsBalanced(string input)
        {
            if (input.ToArray().Count() != 0)
            { 
                if(input.ToArray()[0] == '(')
                {
                    myStak.Push('(');
                }
                else if(input.ToArray()[0] == ')')
                {
                    if (myStak.Count != 0)
                        myStak.Pop();
                    else
                    {
                        //not balanced
                        return false;
                    }
                }
                return IsBalanced(input.Substring(1));
            }
            else
            {
                if (myStak.Count == 0)
                {
                    //balanced
                    return true;
                }
                else
                {
                    //not balanced
                    return false;
                }
            }
        }
