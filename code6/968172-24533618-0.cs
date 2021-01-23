    var lockIsHeld = false;
    try {
       try {
       }
       finally {
          rwl.EnterReadLock();
          lockIsHeld = true;
       }
     
       // Do work here
    }
    finally {
       if (lockIsHeld) {
          rwl.ExitReadLock();
       }
    }
 
