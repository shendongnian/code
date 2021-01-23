    public static double[,] GetMapSection(Rectangle area, double[,] map) {
        double[,] result = new double[area.Width, area.Height];
    
        for (Int32 y = 0; y < area.Height; ++y) {
            for (Int32 x = 0; x < area.Width; ++x) {
                result[x, y] = map[x + area.X, y + area.Y];
            }
        }
        return result;
    }
