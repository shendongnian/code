    class Program
    {
        private static void Execute()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                // save it temporarily and pass the temp_var variable
                int tmp_var = i;
                actions.Add(new Action(() => DoSomething(tmp_var)));
            }
            Parallel.Invoke(actions.ToArray());
        }
        private static void DoSomething(int value)
        {
            Console.WriteLine("Did something #" + value);
        }
        static void Main(string[] args)
        {
            Execute();
            Console.ReadKey();
        }
    }
