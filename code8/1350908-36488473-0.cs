    static void Main(String[] args)
        {
            string input = "{([[}))";
    
            Stack<char> mystack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                    mystack.Push(input[i]);
                else if (input[i] == '}' && mystack.Peek() == '{')
                {
                    mystack.Pop();
                }
                else if (input[i] == ')' && mystack.Peek() == '(') {
                    mystack.Pop();
                }
                else if (input[i] == ']' &&  mystack.Peek() == '[')
                {
                    mystack.Pop();
                }
            }
    
            if(mystack.Count == 0)
                Console.WriteLine("Correct Input");
            else Console.WriteLine("Incorrect input");
    
            Console.ReadKey();
        }
