        public void ParentFunction()
        {
          try
          {
             foreach (var item in someArray)
             {
               //If an error occurred in flowing Try-Catch Skip
               // and foreach go to next item
               try
               {
                   procedure1();
                   procedure2();
                   procedure3();
               }
               catch(Exception exc)
               {
                    //Here you can Handle your procedures error
                    console.Writeline(exc.Message);
               }
             }
          }
          catch(Exception exc)
          {
             console.Writeline(exc.Message);
          }
        }
