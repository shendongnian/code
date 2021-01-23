    public PersonViewModel()
    {
       SaveDataCommand = new DelegatingCommand(SaveData, ()=> flag);
    }
    
    bool flag;
    public bool IsValidObject
    {
        get 
        { 
            var context = new ValidationContext(EmpInfo, null, null);
            flag = Validator.TryValidateObject(EmpInfo, context, null, true);
            SaveDataCommand.RaiseCanExecute() // don't know what type of command you have but you should have a method which you can call something with Canexecute
            return flag;
        }
    }
    
    public bool ValidateEmployeeObject()
    {
      return IsValidObject;
    }
    public ICommand SaveDataCommand { get;  }
