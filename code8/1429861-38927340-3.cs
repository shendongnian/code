    private struct Temp
        {
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
            public Temp(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }
    Console.WriteLine(Marshal.SizeOf(new Temp(1, 2, 3))); // 12
