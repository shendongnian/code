    private void timerDoJob_Elapsed(object sender, ElapsedEventArgs e)
    {
         timerDoJob.Change(Timeout.Infinite, 0);
         
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
