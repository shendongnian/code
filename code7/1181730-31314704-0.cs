    Use following code it might be work because in my case it's working.
    
    
    <i:Interaction.Triggers>
            <i:EventTrigger EventName="Loaded">
                <i:InvokeCommandAction Command="{Binding WindowLoadedCommand}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    
    ViewModel.cs,
    
      
       public ICommand WindowLoadedCommand
        {
            get { return new RelayCommand<object>(WindowLoadedCommandExecute); }
        }
        public void WindowLoadedCommandExecute(object obj)
        {
        }
