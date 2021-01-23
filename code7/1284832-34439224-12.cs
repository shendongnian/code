    Interface ICommandBase
    {
        object[] parameters {get; set;}
        void Execute();    
    }
    
    abstract class InternalCommand : ICommandBase
    {
        //Some methods that are common to all your intzernal commands
    }
    
    class SetColorCommand : InternalCommand //Or it might derive from ICommandBase directly if you dont need to categorize it
    {
         object[] parameters {get; set;}
         void Execute()
         {
             switch (parameters[0])
             {
                  case "background":
                      //Set the background color to parameters[1]
                  break;
                  case "foreground":
                        //...
                  break;
             }
         }
    }
    
    class SqlCommand : ICommandBase
    // Or it might derive from ICommandBase directly if you don't need to categorize it
    {
         object[] parameters {get; set;}
         void Execute()
         { 
              //Parameters[0] would be the sql string...
         } 
    }
