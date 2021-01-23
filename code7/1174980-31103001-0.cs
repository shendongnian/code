    void drawX(int spaces, int x)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < spaces + x ; i++)
        {
            sb.append((i<=spaces) ? " " : "x");
        }
        Console.write(sb.ToString());
    }
