      public ICommand ExitCommand
        {
               get
               {
                   return new DelegateCommand
                   {
                       CommandAction = () =>
                       {
                           ((App)Application.Current).CustomShutdown(); 
                       }
                   };
                }
             }
         }
