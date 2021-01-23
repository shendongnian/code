    void Main()
    {
        //This var will be a Task<TResult>
        var resultTask = ExecuteActionAsync(async() => //This will likely not compile because there 
                                                       // is no return type for TResult to be.
            {
                // Will contain real async code in production
                throw new ApplicationException("Triggered exception");
            }
        );
        //I am only using .Result here becuse we are in Main(), 
        // if this had been any other function I would have used await.
        var result = resultTask.Result; 
    }
    
    public virtual async TResult ExecuteActionAsync<TResult>(Func<Task<TResult>> func, object state = null)
    {
        try
        {
            return await func(); //Now func will raise the exception.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught with error {ex.Message}");
            return default(TResult);
        }
    }
