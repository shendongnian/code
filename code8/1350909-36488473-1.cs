    static void Main(String[] args)
    {
        string input = "{()}";
        bool success = true;
        HashSet<char> openBrackets = new HashSet<char>() { '(', '{', '[' };
        HashSet<char> closeBrackets = new HashSet<char>() { ')', '}', ']' };
        Stack<char> mystack = new Stack<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (openBrackets.Contains(input[i]))
                mystack.Push(input[i]);
            else if (closeBrackets.Contains(input[i])){
                if(mystack.Count == 0)
                {
                    success = false;
                    break;
                }
                if (input[i] == '}' && mystack.Peek() == '{')
                        mystack.Pop();
                else if (input[i] == ')' && mystack.Peek() == '(')
                        mystack.Pop();
                else if (input[i] == ']' && mystack.Peek() == '[')
                        mystack.Pop();
                else
                {
                    success = false;
                    break;
                }
            }
             
            
        }
        if (mystack.Count == 0 && success)
            Console.WriteLine("Correct Input");
        else Console.WriteLine("Incorrect input");
        Console.ReadKey();
    }
