    public async Task AttemptDatabaseLoadAsync()
    {
        while(ConnectionAttempts < MAX_CONNECTION_ATTEMPTS){
            Task<bool> Attempt = TryLoad ();
            bool success = await Attempt;
            if (success) {
                //call func to load data into program memory proper
            }else{
                ConnectionAttempts++;
            }
        }
    }
    public async Task DataLoaderAsync ()
    {
        //First load up current data from local sqlite db
        LoadFromLocal();
        //Then go for an async load from 
        await AttemptDatabaseLoadAsync();
    }
    public void DataLoader()
    {
        Task task= DataLoaderAsync();
        task.Wait(); 
    }
