    partial class Program
    {
        static void Main(string[] args)
        {
            Task withUnwrap = Unwrap_IndefinitelyBlockingTask();
            Task<Task> withAwait = AwaitVersion_IndefinitelyBlockingTask();
            withAwait.Wait();
            //withUnwrap.Wait();
        }
        static async Task<Task> AwaitVersion_IndefinitelyBlockingTask()
        {
            List<Task> tasks = new List<Task>();
            Task task = FooAsync();
            tasks.Add(task);
            Task<Task<Task>> continuationTask = task.ContinueWith(async t =>
            {
                //immediately returns with generated Task<Task> return type task 
                await Task.Delay(10000);
                List<Task> childtasks = new List<Task>();
                ////get child tasks
                //now INSTEAD OF ADDING CHILD TASKS, i added outer method TASKS. Typo :(:)!
                //!!since we added compiler generated task to outer task its deadlock!!
                Task wa = Task.WhenAll(tasks/*TYPO*/);
                await wa.ConfigureAwait(continueOnCapturedContext: false);
                return wa;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            tasks.Add(continuationTask);
            //Task unwrappedTask = continuationTask.Unwrap();
            Task<Task> awaitedComiplerGeneratedTaskOfContinuationTask = await continuationTask;
            tasks.Add(awaitedComiplerGeneratedTaskOfContinuationTask);
            Task whenall = Task.WhenAll(tasks.ToArray());
            return whenall;
        }
        static async Task FooAsync()
        {
            await Task.Delay(20000);
        }
        static Task Unwrap_IndefinitelyBlockingTask()
        {
            List<Task> tasks = new List<Task>();
            Task task = FooAsync();
            tasks.Add(task);
            Task<Task> continuationTask = task.ContinueWith(t =>
            {
                Task.Delay(10000);
                List<Task> childtasks = new List<Task>();
                ////get child tasks
                //now INSTEAD OF ADDING CHILD TASKS, i added outer method TASKS. Typo :(:)!
                //!!since outer tasks contain 'unwrapped' proxy task there is deadlock!!
                Task wa = Task.WhenAll(tasks/*TYPO*/);
                return wa;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            tasks.Add(continuationTask);
            Task unwrappedTask = continuationTask.Unwrap();
            tasks.Add(unwrappedTask);
            Task whenall = Task.WhenAll(tasks.ToArray());
            return whenall;
        }
    }
