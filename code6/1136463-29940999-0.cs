    private ICommand clickMeCommand;
 
    public ICommand ClickMeCommand
    {
       get 
         {
            if(clickMeCommand == null)
                clickMeCommand = new RelayCommand(i => this.ClickMe(), i=> this.CanClick());
         }
    }
