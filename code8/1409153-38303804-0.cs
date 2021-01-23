    Dictionary<string, Task<string>> tasks = new Dictionary<string, Task<string>>();
    public async Task<string> GetCustomer(int id)
    {
        string taskName = $"get-customer-{id}";
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
        lock (tasks)
        {
            tasks.Remove(taskName);
        }
        return result;
    }
    private string GetCustomerInternal(int id)
    {
        return "hello";
    }
