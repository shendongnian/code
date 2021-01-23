    private RelayCommand<string> toDoCommand{ get; set; }
        
    public ICommand ToDoCommand
                {
                    get
                    {
                        if (null == toDoCommand)
                            toDoCommand= new RelayCommand<string>(ToDoMethod);
        
                        return toDoCommand;
                    }
                }
    private void ToDoMethod(string obj)
        {
            var a = obj; //its the CommandParameter="1" its the 1
        }
