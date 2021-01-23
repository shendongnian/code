    lock(MyResult)
    {
      if(MyResultIsModified)
      {
        // ... do whatever with MyResult ..
        MyResultIsModified = false;
      }
    }
