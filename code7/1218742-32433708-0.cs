    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    internal class Program
    {
        private static void Main()
        {
            var queue1 = new ConcurrentQueue<int>();
            var queue2 = new Queue<int>();
            // This will work fine.
            var task1 = Task.Run(() => producer(item => queue1.Enqueue(item)));
            var task2 = Task.Run(() => producer(item => queue1.Enqueue(item)));
            Task.WaitAll(task1, task2);
            // This will cause an exception.
            var task3 = Task.Run(() => producer(item => queue2.Enqueue(item)));
            var task4 = Task.Run(() => producer(item => queue2.Enqueue(item)));
            Task.WaitAll(task3, task4);
        }
        private static void producer(Action<int> add)
        {
            for (int i = 0; i < 10000; ++i)
                add(i);
        }
    }
