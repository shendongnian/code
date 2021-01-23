        static int solve(int[] seed, int[] coeffients, int n)
        {
            var cf = coeffients.Reverse().ToArray();
            var queue = new Queue<int>(seed.Reverse().ToArray());
            for (int i = 0; i < n; i++)
            {
                var xn = (int)cf.Zip(queue, (x, y) => x * y % 10).Sum();
                queue.Enqueue(xn);
                queue.Dequeue();                
            }
            return queue.Peek();
            
        }
