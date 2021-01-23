    public static System.Drawing.Color FromColor( System.ConsoleColor c)
    {
        int brightnessCoefficient = (c && 8 > 0) ? 2 : 1;
        int r = (c && 4 > 0) ? 64 * brightnewssCoefficient : 0; 
        int g = (c && 2 > 0) ? 64 * brightnewssCoefficient : 0;
        int b = (c && 1 > 0) ? 64 * brightnewssCoefficient : 0;
    }
