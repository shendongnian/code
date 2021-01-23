    public class ButtonViewModel
    {
        public string Caption { get; set; } 
    }
    
    public class ViewModel
    {
        public ViewModel()
        {
           Buttons = new ObservableCollection<ButtonViewModel>
           {
               new ButtonViewModel { Caption = "Button 1" },
               new ButtonViewModel { Caption = "Button 2" },
               new ButtonViewModel { Caption = "Button 3" },
           };
        }
    
        public ObservableCollection<ButtonViewModel> Buttons { get; }  
    }
