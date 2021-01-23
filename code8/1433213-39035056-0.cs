    public PersonViewModel()
    {
       SaveDataCommand = new DelegatingCommand(SaveData, ()=> IsValidObject);
    }
    public bool IsValidObject
    {
        get 
        { 
            var context = new ValidationContext(EmpInfo, null, null);
            bool flag = Validator.TryValidateObject(EmpInfo, context, null, true);
            SaveDataCommand.RaiseCanExecute() // don't know what type of command you have but you should have a method which you can call something with Canexecute
            return flag;
        }
    }
    
    public ICommand SaveDataCommand { get;  }
