        public static async void DisplayString()
        {
            Task<string> task = new Task<string>(
                () => { Thread.Sleep(10); return "ok"; });
            task.Start();
            Console.WriteLine(await task);
        }
