       if (localCopy % 2 == 0) 
       {
            ...
            barrier.SignalAndWait();       // arrival at B
        }
        else 
        {
            ...
            barrier.RemoveParticipant();   // return to A
            return;
        }
        ...
        barrier.SignalAndWait();           // arrival at C
