    Parallel.For(0, arrCounter, (i, loopState) =>
    {
       AlertToQueueInput input = new AlertToQueueInput();
       input.Message = Messages[i];
       var code = scCommunication.AlertToQueue(input).ReturnCode;
        if (code != 0)
        {
            outputPC.ReturnCode = code ;
             loopState.Break();
        }
    
    });
