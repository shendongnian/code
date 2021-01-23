    public override bool SyncNavigationMethod()
        {
            List<Task> taskList = new List<Task>();
            taskList.Add(AsyncShowDialog());
            Task.WhenAll(taskList.ToArray());
            return true;
        }
        
        public async Task AsyncShowDialog()
        {
            await SomeOperation();
        }
