    static void Main(string[] args)
    {
        Console.WriteLine("<ul>");
        string[] listWithElements = { "q", "a", "a", "q", "a", "q", "a", "a", "q" };
        List<int> stack = new List<int>();
        stack.Add(0);
        foreach (var c in listWithElements)
        {
            while (stack[stack.Count() - 1] == 2 && stack.Count() > 1)
            {
                Console.WriteLine("</ul>");
                stack.RemoveAt(stack.Count() - 1);
            }
            stack[stack.Count() - 1]++;
            Console.WriteLine("<li>");
            if (listWithElements[stack.Count() - 1] == "q")
            {
                stack.Add(0);
                Console.WriteLine("qqq");
                Console.WriteLine("<ul>");
            }
            else
            {
                Console.WriteLine("aaa");
                Console.WriteLine("</li>");
            }
        }
        Console.WriteLine("</ul>");
    }
