    public class ComUplink : INotifyPropertyChanged
    {
        private String connectionStatus = "Idle";
        public String ConnectionStatus
        {
            get
            {
                return this.connectionStatus;
            }
            set
            {
                this.connectionStatus = value;
                this.OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Socket Socklink;
    }
