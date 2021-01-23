    public class ApplicationCommand : RelayCommand
    {
        string commandName;
        public void Execute()
        {
            // No try-catch, I never code bugs ;o)
            Log.Info("Prepare to execute the command " + commandName);
            base.Execute();
            Log.Info("Finished to execute the command " + commandName);
        }
        public static void SetCommand(MyViewModel vm, 
                                      Expression<Func<MyViewModel,ICommand>> commandSelector, 
                                      Action action){
           var me = commandSelector.Body as MemberExpression;
           if(me == null) throw new ArgumentException("Invalid command  selector!");
           var newCommand = new ApplicationCommand(action);
           newCommand.commandName = me.Member.Name;           
           vm.GetType()
             .GetProperty(newCommand.commandName)
             .SetValue(vm, newCommand, null);
        }
    }
    //then use it like this
    public MyViewModel()
    {
        ApplicationCommand.SetCommand(this, e => e.BlinkCommand, () => DoBlink());
        ApplicationCommand.SetCommand(this, e => e.CheckCommand, () => DoCheck());
    }
