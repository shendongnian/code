    async void Foo()
    {
        try
        {
            var result = await GetMyTask();
            ProcessResult(result);
        }
        catch(Exception ex)
        {
            // handle the exception somehow, or ignore it (not recommended)
        }
    }
