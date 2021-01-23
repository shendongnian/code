    private readonly object obj = new object();
    
    public Task<string> MyTask(ushort Id)
    {
        lock(obj)
        {
            String MyString;
            //do something
            return Task.FromResult(MyString);
        }
    }
