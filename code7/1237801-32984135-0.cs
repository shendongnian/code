    class Counter
    {
        public int Index;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int width = 100;
            int height = 100;
            int[] output = new int[width * height];
            int partitionCount = 10;
            Task[] tasks = new Task[partitionCount];
            var counter = new Counter();
            for (int p = 0; p < partitionCount; p++)
            {
                int current = p;
                tasks[p] = Task.Run(() =>
                {
                    int batchSize = height / partitionCount;
                    int yStart = current * batchSize;
                    int yEnd = current == partitionCount - 1 ? height : yStart + batchSize;
                    Apply(output, width, height, yStart, yEnd, counter);
                });
            }
            Task.WaitAll(tasks);
        }
        static void Apply(int[] output, int width, int height, int startY, int endY, Counter counter)
        {
            for (int y = startY; y < endY; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    output[Interlocked.Increment(ref counter.Index) -1] = y + x;
                }
            }
        }
    }
