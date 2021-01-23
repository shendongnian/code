    public void SomeMethod()
        List<Task> tasks = new List<Task>();
        for (var i = 0; i < 100; i++)
        {
            tasks.Add(Task.Run(() => GetDataFor(i)).ContinueWith((antecedent) => {
                // Process the results here.
            }));
        }
        Task.WaitAll(tasks.ToArray());
    }
