    int altura; string space = ""; int cont2 = 0;
    Console.Write("Dar altura: ");
    altura = int.Parse(Console.ReadLine());
    for (int i = 1; i <= altura; i++)
    {
        var stack = new System.Collections.Generic.Stack<int>();
        space = "";
        for (int j = 1; j <= i; j++)
        {
            space = space + Convert.ToString(j);
            stack.Push(j);
        }
        stack.Pop();
        while (stack.Count > 0)
        {
           space = space + Convert.ToString(stack.Pop())
        }
        Console.WriteLine(space);
    }
    Console.ReadLine();
