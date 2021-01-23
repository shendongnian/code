      public ICommand ExitCommand
        {
               get
               {
                   return new DelegateCommand
                   {
                       CommandAction = () =>
                       {
                           Application.Current.Shutdown(); // <-- Don't do this
                       }
                   };
                }
             }
         }
