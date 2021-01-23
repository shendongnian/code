    internal class Command1 : ICommand
    {
       
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        public async void Execute(object parameter)
        {
            var ctx = (CommandContext)parameter;
            var newCTX =   await Task<CommandContext>.Run(() => {
                //the command context is here running in it's own independent Task
                //Any changes here are only known here, unless we return the changes using a 'closure'
                //the closure is this code - var newCTX = await Task<CommandContext>Run
                //newCTX is said to be 'closing' over the task results
                ctx.Data = GetNewData();
                return ctx;
            });
            newCTX.NotifyNewCommmandContext();
        }
        private RequiredData GetNewData()
        {
            throw new NotImplementedException();
        }
    }
   
