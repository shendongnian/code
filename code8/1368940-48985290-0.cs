            public static bool ValidBraces(String braces)
            {
                if (String.IsNullOrWhiteSpace(braces))
                {
                    //invalid
                    return false;
                }
    
                Stack<char> stack = new Stack<char>();
    
                for (int i = 0; i < braces.Length; i++)
                {
                    //if its an open brace, stack
                    if (braces[i] == '{' || braces[i] == '[' || braces[i] == '(')
                    {
                        stack.Push(braces[i]);
                    }
                    else if (stack.Count != 0)
                    {
                        //if its a closed brace, compare with the complement and pop from stack
                        if (stack.Pop() != complement(braces[i]))
                        {
                            //invalid
                            return false;
                        }
                    }
                    else
                    {
                        //invalid, missing brace
                        return false;
                    }
                }
    
                if (stack.Count != 0)
                {
                    //invalid, there are still some braces without match
                    return false;
                }
    
                //valid, success
                return true;
            }
    
            private static char complement(char item)
            {
                switch (item)
                {
                    case ')':
                        return '(';
                    case '}':
                        return '{';
                    case ']':
                        return '[';
                    default:
                        return ' ';
                }
            }
            //this is for test. Put it on some method.
            System.Console.WriteLine("" + ValidBraces(""));//false
            System.Console.WriteLine("()" + ValidBraces("()"));//true
            System.Console.WriteLine("[(])" + ValidBraces("[(])"));//false
            System.Console.WriteLine("[()]{}" + ValidBraces("[()]{}"));//true
            System.Console.WriteLine("[({)]}" + ValidBraces("[({)]}"));//false
            System.Console.WriteLine("[[()]{}" + ValidBraces("[[()]{}"));//false
