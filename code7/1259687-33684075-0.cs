        public void Main()
        {
            List<string> list = new List<string>(3)
            { "a", "b", "c"};
            for (int i = 0; i < list.Count; i++)
            {
                int yy = i;
                AFunctionWithLambda(() => Console.WriteLine(list[yy]));
            }
            Thread.Sleep(1000);
            Console.WriteLine("all done, probably");
            Console.ReadLine();
        }
        private void AFunctionWithLambda(Action action)
        {  // runs it asynchronously, for giggles
            ThreadPool.QueueUserWorkItem(o => {
                Thread.Sleep(500); // delay, to let the loop finish
                action();
            });
        }
