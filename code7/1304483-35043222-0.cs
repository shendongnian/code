    <Button Content="Some Button">
            <inter:Interaction.Triggers>
                <inter:EventTrigger EventName="PreviewMouseLeftButtonDown">
                    <inter:InvokeCommandAction Command="{Binding ButtonDown}"/>
                </inter:EventTrigger>
                <inter:EventTrigger EventName="PreviewMouseLeftButtonUp">
                    <inter:InvokeCommandAction Command="{Binding ButtonUp}"/>
                </inter:EventTrigger>
            </inter:Interaction.Triggers>
        </Button>
     public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ButtonDown = new RelayCommand(OnButtonDown);
            ButtonUp = new RelayCommand(OnButtonUp);
        }
        public RelayCommand ButtonDown { get; set; }
        public RelayCommand ButtonUp { get; set; }
        private void OnButtonUp()
        {
            Debug.WriteLine("Button Released");
        }
        private void OnButtonDown()
        {
            Debug.WriteLine("Button Pressed");
        }
    }
