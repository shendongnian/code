    public static void DrawPyramid(int Rows)
    {
        string Pyramid = string.Empty;
        int n = Rows;
        for (int i = 0; i <= n; i++)
        {
            for (int j = i; j < n; j++)
            {
                Pyramid += " ";
            }
            for (int k = 0; k < 2 * i - 1; k++)
            {
                Pyramid += "*";
            }
            Pyramid += Environment.NewLine;
        }
        Pyramid.ConsoleWrite();
    }
