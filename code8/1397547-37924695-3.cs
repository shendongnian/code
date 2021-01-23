    public class X : INotifyPropertyChanged
    {
        private int kills = 0;
        public int Kills
        {
            get
            {
                return kills;
            }
            set
            {
                this.kills = value;
                this.OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler pc = this.PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
