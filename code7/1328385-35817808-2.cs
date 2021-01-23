    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var factoryCancellation = new CancellationTokenSource();
            var scheduler = new LimitedConcurrencyLevelTaskScheduler(maxDegreeOfParallelism: 7);
            var taskFactory = new TaskFactory(factoryCancellation.Token, TaskCreationOptions.None, TaskContinuationOptions.None, scheduler);
            var taskCancellation1 = new CancellationTokenSource();
            var taskCancellation2 = new CancellationTokenSource();
            var token1 = taskCancellation1.Token;
            var token2 = taskCancellation2.Token;
            var myTask1 = taskFactory.StartNew(async () => await Execute(0, token1), token1).Unwrap();
            var myTask2 = taskFactory.StartNew(async () => await Execute(1, token2), token2).Unwrap();
            taskCancellation1.CancelAfter(500);
            try
            {
                await Task.WhenAll(myTask1, myTask2);
            }
            catch
            {
                //ThrowIfCancellationRequested Exception
            }
        }
        private async Task Execute(int i, CancellationToken token)
        {
            Console.WriteLine($"Running Task {i} : Before Delay 1");
            await Task.Delay(1000);
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Running Task {i} : Before Delay 2");
            await Task.Delay(1000);
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Running Task {i} : Before Delay 3");
            await Task.Delay(1000);
            token.ThrowIfCancellationRequested();
        }
    }
