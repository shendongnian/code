    outputPC.ReturnCode = Messages
        .AsParallel()
        .Select(msg =>    
        {
           AlertToQueueInput input = new AlertToQueueInput();
           input.Message = msg;        
           return scCommunication.AlertToQueue(input).ReturnCode;
        })
        .FirstOrDefault(r => r != 0);
