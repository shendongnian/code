    int GetReturnCode(...)
    {
        Parallel.For(0, arrCounter, i =>
        {
            AlertToQueueInput input = new AlertToQueueInput();
            input.Message = Messages[i];
            var result = scCommunication.AlertToQueue(input).ReturnCode;
            if (result != 0) return result;
        });
        return 0;
     }
    
