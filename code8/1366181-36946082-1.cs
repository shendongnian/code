    private void timerDoJob_Elapsed(object sender, ElapsedEventArgs e)
    {
         timerDoJob.Change(Timeout.Infinite, 0);
         
         // Use a try-finally so if some tasks throws an exception
         // the timer will be re-enabled again anyway
         try
         {
            VeryLongTask1();
            VeryLongTask2();
            VeryLongTask3();
         }
         finally
         {
             timerDoJob.Change(0, 5000);
         }
    }
