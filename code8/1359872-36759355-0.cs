    static void Main(string[] args)
        {
            bool error = false;
            var str = "( a[i]+{-1}*(8-9) )";
            Stack<char> stack = new Stack<char>();
            foreach (var item in str.ToCharArray())
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                }
                else if(item == ')' || item == '}' || item == ']')
                {
                    if (stack.Peek() != GetComplementBracket(item))
                    {
                        error = true;
                        break;
                    }
                }
            }
            if (error)
                Console.WriteLine("Incorrect brackets");
            else
                Console.WriteLine("Brackets are fine");
            Console.ReadLine();
        }
        private static char GetComplementBracket(char item)
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
