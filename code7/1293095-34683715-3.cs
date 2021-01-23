    <Button Content="Save" Grid.Row="1" Height="23" HorizontalAlignment="Left" Margin="310,50,0,0" Name="btnSave" 
                VerticalAlignment="Top" Width="141"
                Command="{Binding Path=SaveCommad}",CommandParameter{Binding}  />
    RelayCommand _saveCommand;    
    public ICommand SaveCommand    
    {    
       get    
       {    
          if (_saveCommand== null)    
          {    
            _saveCommand= new RelayCommand(p => this.SaveCommand((object)p),    
            p => this.CanSaveCommand(p) ); // you can set it to true for testing purpose or bind it to a property IsValid if u want to disable the button   
          }    
        return _saveCommand;    
       }
    
    }
    private void SaveCommand(object vm)
    {
         //Actual implementation to insert into list.
    }
    private bool CanSaveCommand(object vm)
    {
        return true;
    }
    YourViewModel : INotifyPropertyChange // to enable notification to your view
    private User _currentUser;
    public User CurrentUser {get return _currentUser;} set{_currentUser = value; NotifyPropertyChange("CurrentUser")
    //Or Simply Insert all property of user to your viewmodel so your input have acces to content
    private string _name;
    public string Name {get return _name;} set{_name = value; NotifyPropertyChange("Name")
 
