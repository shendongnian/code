        private static void Main()
        {
            var queue1 = new ConcurrentQueue<int>();
            var queue2 = new Queue<int>();
            // This will work fine.
            var task1 = Enumerable.Range(0, 40)
                .Select(_ => Task.Run(() => producer(item => queue1.Enqueue(item))))
                .ToArray();
            Task.WaitAll(task1);
            // This will cause an exception.
            var task2 = Enumerable.Range(0, 40)
                            .Select(_ => Task.Run(() => producer(item => queue2.Enqueue(item))))
                            .ToArray();
            Task.WaitAll(task2);
        }
