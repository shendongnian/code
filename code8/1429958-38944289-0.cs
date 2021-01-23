    class Program
    {
        static void Main(string[] args)
        {
            //use AsyncContext, provided by the Nito.AsyncEx library
            AsyncContext.Run(() => MainAsync(args));
        }
        static async void MainAsync(string[] args)
        {
            var taskList = new List<Task>();
            for (int i = 0; i < 128; i++)
            {
                //add the new Task to the list and start to execute it
                taskList.add(DoStuffAsync());
            }
            		
            //wait for all to finish
            await Task.WhenAll(taskList);
        }
		
        private static async Task DoStuffAsync()
        {
            //do async stuff, like download from webpage
        }
    }
