    public class MyThread
    {
        public static object locker = new object();
        public static void Thread1()
        {
            for (; Program.count < Program.numbers.Count;)
            {
                lock (locker)
                {
                    Console.WriteLine(Program.numbers[Program.count]);
                    Program.count++;
                }
            }
        }
    }
