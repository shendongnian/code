    class DataLoader
    {
 
    public DataLoader ()
    {
        //First load up current data from local sqlite db
        LoadFromLocal();
        //Then go for an async load from 
        this.Completion = AttemptDatabaseLoadAsync();
    }
    async Task AttemptDatabaseLoadAsync()
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
    public Task Completion
    {
        get; private set;
    }
 
    }
