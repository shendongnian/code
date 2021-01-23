    private static int GetPosition(double value, int startPosition, int maxPosition, double weightFactor, double rMin)
    {
        while (true)
        {
            if (startPosition == maxPosition) return maxPosition;
            var limit = (1 - rMin)*weightFactor + rMin;
            if (value < limit) return startPosition;
            startPosition = startPosition + 1;
            rMin = limit;
        }
    }
    static void Main()
    {
        const int maxIndex = 100;
        const double weight = 0.1;
        var r = new Random();
        for (var i = 0; i < 200; i++)
            Console.Write(GetPosition(r.NextDouble(), 0, maxIndex, weight, 0) + " ");
    }
