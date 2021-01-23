        static async Task Test()
        {
            TextResult result;
            var cts = new CancellationTokenSource();
            var classNameTasks = Enumerable.Range(1, 200).Select(i => getSplittedClassName(cts)).ToArray();
            await classNameTasks.WhenAll(cts.Token);
            if (cts.IsCancellationRequested)
                result = new TextResult("Error accessing the web");
            string[][] splittedClassNames = classNameTasks.Select(t => t.Result).ToArray();
        }
        private static async Task<string[]> getSplittedClassName(CancellationTokenSource cts)
        {
            try
            {
                //real code goes here
                await Task.Delay(1000, cts.Token); //the token would be passed to the real web method
                return new string[0];
            }
            catch
            {
                cts.Cancel(); //stop trying
                return null;
            }
        }
