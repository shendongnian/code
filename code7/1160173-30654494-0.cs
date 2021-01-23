    static int[] a = new int[100000000];
    static void calc(int f, int l, int[] p, int[] a)
    {
        for (int i = f; i < l; i++)
        {
            if (a[i] >= 1000000000) { p[10] += 1; }
            else if (a[i] >= 100000000) { p[9] += 1; }
            else if (a[i] >= 10000000) { p[8] += 1; }
            else if (a[i] >= 1000000) { p[7] += 1; }
            else if (a[i] >= 100000) { p[6] += 1; }
            else if (a[i] >= 10000) { p[5] += 1; }
            else if (a[i] >= 1000) { p[4] += 1; }
            else if (a[i] >= 100) { p[3] += 1; }
            else if (a[i] >= 10) { p[2] += 1; }
            else { p[1] += 1; }
        }
    }
    public static void _Main(string[] args)
    {
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = i;
        }
        int f = 0;
        int l = a.Length;
        int[] p = new int[10];
        int[] p1 = new int[10];
        int[] p2 = new int[10];
        int[] p3 = new int[10];
        int[] p4 = new int[10];
        int[] a1 = new int[l / 2];
        int[] a2 = new int[l / 2];
        int[] a11 = new int[l / 4];
        int[] a12 = new int[l / 4];
        int[] a13 = new int[l / 4];
        int[] a14 = new int[l / 4];
        for (int i = 0; i < a.Length; i++)
            if (i >= l / 2)
                a2[i - l / 2] = a[i];
            else
                a1[i] = a[i];
        for (int i = 0; i < a.Length; i++)
            if (i >= l / 4 * 3)
                a14[i - l / 4 * 3] = a[i];
            else if (i >= l / 4 * 2)
                a13[i - l / 4 * 2] = a[i];
            else if (i >= l / 4 * 1)
                a12[i - l / 4] = a[i];
            else
                a14[i] = a[i];
        int rc = 5;
        for (int d = 0; d < rc; d++)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            Parallel.Invoke(() => calc(f, l / 2, p1, a1), () => calc(f, l / 2, p2, a2));
            w.Stop();
            Console.WriteLine("Attempt {0}/{1}: {2}", 1, d, w.ElapsedMilliseconds);
            w.Reset();
            w.Start();
            Parallel.Invoke(() => calc(f, l / 4, p1, a11), () => calc(f, l / 4, p2, a12), () => calc(f, l / 4, p3, a13), () => calc(f, l / 4, p4, a14));
            w.Stop();
            Console.WriteLine("Attempt {0}/{1}: {2}", 2, d, w.ElapsedMilliseconds);
            w.Reset();
            w.Start();
            Parallel.Invoke(() => calc(f, l / 2, p, a), () => calc(l / 2, l, p, a));
            w.Stop();
            Console.WriteLine("Attempt {0}/{1}: {2}", 3, d, w.ElapsedMilliseconds);
            w.Reset();
            w.Start();
            calc(f, l, p, a);
            w.Stop();
            Console.WriteLine("Attempt {0}/{1}: {2}", 4, d, w.ElapsedMilliseconds);
        }
    }
