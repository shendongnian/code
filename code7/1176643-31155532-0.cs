    private bool StartQueueProcess(
         string param1, 
         int param2, 
         int param3, 
         Action<string, int, int> processMethod)
    {
        Task.Factory.StartNew(() => processMethod(param1, param2, param3));
    }
