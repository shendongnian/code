    Task<object> testTask = Task.Factory.StartNew(
        async (obj) =>
            {
                ...
            }
        ).Unwrap();
