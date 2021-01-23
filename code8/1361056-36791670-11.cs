    public class MyThreadingClass
    {   
        private Task ExecuteWebServiceCallAsync()
        {
            return await _myService.DoSomething();
        }
        
        private Task ExecuteDbQueryAsync()
        {
            return await _context.Customer.FirstOrDefaultAsync();
        }
    
        public void DoThingsWithWaitAll()
        {
            var tasks = new Task[2];
            // Fire up first task.
            tasks[0] = ExecuteWebServiceCallAsync();
            // Fire up next task.
            tasks[1] = ExecuteDbQueryAsync();
            // Wait for all tasks.
            Task.WaitAll(tasks);
        }
        
        public Task DoThingsWithWithAwaitAsync()
        {
            // Fire up first task.
            var webServiceTask = ExecuteWebServiceCallAsync();
            // Fire up next task.
            var dbTask = ExecuteDbQueryAsync();
            // Wait for all tasks.
            await webServiceTask;
            await dbTask;
        }
    }
