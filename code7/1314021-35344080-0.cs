    public async Task<void> SomeMethod()
    {
        for(int i = 0; i < 100; i++) {
            var task = Task.Run(() => GetDataFor(i)).ContinueWith((antecedent) => {
                // Process the results here.
            });
        }
        Task.WaitAll();
    }
