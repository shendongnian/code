    public class SomeBaseClass : INotifyPropertyChanged
    {
        // Other common functionality goes here..
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]// Commment out if your don't have R#
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
