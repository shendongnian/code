    int[] pageResults = new int[arrCounter];
    Parallel.For(0, arrCounter, (i, loopState) =>
        {
           AlertToQueueInput input = new AlertToQueueInput();
           input.Message = Messages[i];
           var code = scCommunication.AlertToQueue(input).ReturnCode;
           pageResults[i] = code ;
            if (code != 0 && outputPC.ReturnCode == 0)
                outputPC.ReturnCode = code ;    
        });
