      int maxLoops = 100;
      bool oneIsBusy = true;
      while (maxLoops-- > 0 && oneIsBusy)
      {
             oneIsBusy = false;
             Thread.Sleep(100);
             Application.DoEvents();
             foreach (Thread thread in ThreadList)
             {
                  oneIsBusy |= thread.IsRunning;
             }
        }
