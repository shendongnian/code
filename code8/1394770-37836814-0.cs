       public ICommand Command { get; set; }
       public void SomeMethod()
       {
           this.Command?.Execute(null);
       }
    }
    //parent code, define the command with the logic to run
    var command = new DelegateCommand(...);
    var control = new Views.PlayingGameScreen
    {
        Command = command
    };
    this.ContentControl.Content = control;
