    class ConsolePixel
    {
        public char Char { get; set; }
        public ConsoleColor Forecolor { get; set; }
        public ConsoleColor Backcolor { get; set; }
        public CieLab Lab { get; set; }
    }
    static List<ConsolePixel> pixels;
    private static void ComputeColors()
    {
        pixels = new List<ConsolePixel>();
        char[] chars = { '█', '▓', '▒', '░' };
        int[] rs = { 0, 0, 0, 0, 128, 128, 128, 192, 128, 0, 0, 0, 255, 255, 255, 255 };
        int[] gs = { 0, 0, 128, 128, 0, 0, 128, 192, 128, 0, 255, 255, 0, 0, 255, 255 };
        int[] bs = { 0, 128, 0, 128, 0, 128, 0, 192, 128, 255, 0, 255, 0, 255, 0, 255 };
        for (int i = 0; i < 16; i++)
            for (int j = i + 1; j < 16; j++)
            {
                var l1 = RGBtoLab(rs[i], gs[i], bs[i]);
                var l2 = RGBtoLab(rs[j], gs[j], bs[j]);
                for (int k = 0; k < 4; k++)
                {
                    var l = CieLab.Combine(l1, l2, (4 - k) / 4.0);
                    pixels.Add(new ConsolePixel
                    {
                        Char = chars[k],
                        Forecolor = (ConsoleColor)i,
                        Backcolor = (ConsoleColor)j,
                        Lab = l
                    });
                }
            }
    }
