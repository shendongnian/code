    static void Main(string[] args)  
    {
        int spaces = int.Parse(Console.ReadLine());
        int symbols = int.Parse(Console.ReadLine());
        DrawX(spaces, symbols);
    }
    static void DrawX(int spaces, int symbols)
    {
        for(int i = 0; i < spaces; i++)
            Console.Write(' ');
        for(int i = 0; i < symbols; i++)
            Console.Write('X');
        // line break
        Console.WriteLine(); 
    }
