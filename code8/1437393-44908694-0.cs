        void Something()
        {
         if (!mybworker.IsBusy())
         { 
          mybworker.RunWorkerAsync(); 
         }
        while (mybworker.IsBusy())
        {
         Application.DoEvents();
        }
       }
