        public static void PrintQueue<T>(object queue)
        {
            var q = (Queue<T>)queue;
            foreach (var i in q)
                Console.WriteLine(i);
        }
