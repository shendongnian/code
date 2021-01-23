    public ICommand ButtonCommand { get; private set; }
    
       
    
         public MyViewModel()
            {
                ButtonCommand = new DelegateCommand<object>(ButtonClick);
            }
        
            private void ButtonClick(object yourParameter)
            {
                //Read 'InputId' somehow. 
                //But DelegateCommand does not allow the method to contain parameters.
            }
