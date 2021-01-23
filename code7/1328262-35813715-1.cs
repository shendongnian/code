    public static async Task getItemAsync(int i)
    {
        string key;
        try 
        {
            key = await getProductKey(i).ConfigureAwait(false);
        } 
        catch 
        {
            // handle exceptions
        }
        // use local variable 'key' in further asynchronous operations
    }
