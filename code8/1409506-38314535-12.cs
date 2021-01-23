    class Save : ICommand
        {
            public ClientModel Model { get; set; }
            public bool CanExecute(object param) { return true; }
            public event EventHandler CanExecuteChanged; //Compiler yells at you if you don't implement this from inhereted ICommand
            public void Execute(object param)
            {
                //TODO: Insert XML serialization and save to a file
                var xml = Helper.Serialize(this.Model);
    
    
                //Placeholder to make sure the button works
                viewModel.DisplayMessage = "You clicked the button at " + DateTime.Now;
            }
        }
