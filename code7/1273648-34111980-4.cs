    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Render(Draw('\u00A9', 4));
        Render(Draw('\u00A9', 8));
        Render(Draw('\u00A9', 16));
    }
    static char[,] Draw(char sym, int height)
    {
        int width = (height * 2) - 1;
        char[,] map = new char[height, width];
        int x = width - 1;
        int y = height - 1;
        for (int i = 0; i < height; i++)
        {
            map[y, i * 2] = sym;
            if (i != 0)
            {
                map[y - i, i] = sym;
                map[y - i, x - i] = sym;
            }
        }
        return map;
    }
    static void Render(char[,] map)
    {
        int width = map.GetLength(1);
        int height = map.GetLength(0);
        for (int i = 0; i < height; i++)
        {
            if (i != 0)
            {
                Console.WriteLine();
            }
            for (int j = 0; j < width; j++)
            {
                char c = map[i, j];
                Console.Write(c == '\0' ? ' ' : c);
            }
        }
        Console.WriteLine();
    }
