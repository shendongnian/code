    Dictionary<string, Task<string>> tasks = new Dictionary<string, Task<string>>();
    public async Task<string> GetCustomer(int id)
    {
        string taskName = $"get-customer-{id}";
        try
        {
            Task<string> task;
            lock (tasks)
            {
                if (!tasks.TryGetValue(taskName, out task))
                {
                    task = new Task<string>(() => GetCustomerInternal(id));
                    tasks[taskName] = task;
                }
            }
            string result = await task;
            return result;
        }
        finally
        {
            lock (tasks)
            {
                tasks.Remove(taskName);
            }
        }
    }
    private string GetCustomerInternal(int id)
    {
        return "hello";
    }
