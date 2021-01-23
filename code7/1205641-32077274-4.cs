    private void StartTask(CancellationToken token)
    {
        Task.Run( () =>
        {
            while (!token.IsCancelRequested)
            {
                List<int> primeNumbersList = WorkOutFirstNPrimeNumbers(500);
                PrintPrimeNumbersToScreen(primeNumbersList);
            }
         })
     }
       
