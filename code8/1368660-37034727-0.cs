    public class MyViewModel : MvxViewModel
    {
        public Action ShowTaskCommandAction {get;set;}
        
        private MvxCommand _showTaskCommand;
        public ICommand ShowTaskCommand =>
            _showTaskCommand = _showTaskCommand ?? (_showTaskCommand = new MvxCommand(DoShowTaskCommand));
    
        private void DoShowTaskCommand()
        {
            CommandAction?.Invoke();
            // do other stuff here...
        }
    }
