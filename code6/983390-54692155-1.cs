        // method to run tasks in a parallel 
        public async Task RunMultipleTaskParallel(Task[] tasks) {
            await Task.WhenAll(tasks);
        }
        // methode to run task one by one 
        public async Task RunMultipleTaskOneByOne(Task[] tasks)
        {
            for (int i = 0; i < tasks.Length - 1; i++)
                await tasks[i];
        }
        // method to run i task in parallel 
        public async Task RunMultipleTaskParallel(Task[] tasks, int i)
        {
            var countTask = tasks.Length;
            var remainTasks = 0;
            do
            {
                int toTake = (countTask < i) ? countTask : i;
                var limitedTasks = tasks.Skip(remainTasks)
                                        .Take(toTake);
                remainTasks += toTake;
                await RunMultipleTaskParallel(limitedTasks.ToArray());
            } while (remainTasks < countTask);
        }
