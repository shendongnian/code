    internal class TrackerViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private readonly IWindow window;
        public TrackerViewModel(ISystemEvents systemEvents, IWindow window)
        {
            if (systemEvents == null)
            {
                throw new ArgumentNullException("systemEvents");
            }
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            systemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            this.window = window;
        }
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
