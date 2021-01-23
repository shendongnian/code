    int loopCount = 0;
    While(true)
    {
        var ListToProcess = massiveSyncQueue.Skip(loopCount*1000).Take(1000);
    
        SubmitPackage(ListToProcess);
    
        if(ListToProcess.Count < 1000)   // We know there are no more in the list massive list.
        {
            break;
        }
        loopCnt++;
    }
