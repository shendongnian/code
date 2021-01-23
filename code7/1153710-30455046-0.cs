    class Program
    {
        static void Main(string[] args)
        {
            var task = test();
            task.Wait(); //this stops async behaviour
            int result = task.Result;// get return value form method "test"
            Console.WriteLine("RESULT IS = " + result);
        }
        public async static Task<int> test()
        {
            int a1, a2, a3, a4;
            //run all tasks
            //all tasks are doing their job "at the same time"
            var taskA1 = GetNumber1();
            var taskA2 = GetNumber2();
            var taskA3 = GetNumber3();
            //wait for task results
            //here I am collecting results from all tasks
            a1 = await taskA1;
            a2 = await taskA2;
            a3 = await taskA3;
            //get value from all task results
            a4 = a1 + a2 + a3;
            return a4;
        }
        public static async Task<int> GetNumber1()
        {
            await Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("GetNumber1");
                        System.Threading.Thread.Sleep(100);
                    }
                });
            return 1;
        }
