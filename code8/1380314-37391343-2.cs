    public class viewModelColorPicker : ViewModelBase 
    {
        modelFont colours = new modelFont();
        public viewModelColorPicker()
        {
        }
        private ObservableCollection<FontColor> fontColours;
        public ObservableCollection<FontColor> FontColours
        {
            get 
            {
                fontColours = colours.AvalibleColours;
                return fontColours;
            }
        }
        private FontColor selectedColour = new FontColor("Black",Brushes.Black); 
        public FontColor SelectedColour
        {
            get 
            {
                selectedColour = colours.SelectedColor.Coalesce(new FontColor("Black",Brushes.Black));                
                return selectedColour; 
            }
            set 
            { 
                SetProperty(ref selectedColour, value, "SelectedColour");
                colours.SelectedColor = value;
            }
        }
    }
