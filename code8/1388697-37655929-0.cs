    void a(int[] g1, int[] g2)
    {
        int counter = 0;
        foreach (var x in g1)
        {
            foreach (var y in g2)
            {
                if (y == x) counter++;
            }
        }
    }
