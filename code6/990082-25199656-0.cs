    private static IEnumerable<int> GenerateSequence()
    {
        const int max = 1000000000;
        const long a = 11268619, b = 4064861;
    
        for(int i = 0; i < max; i++)
        {
            int c = (int)((a * i + b) % max);
            yield return c;
        }
    }
