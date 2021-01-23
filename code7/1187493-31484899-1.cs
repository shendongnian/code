    public class Class2 : INotifyPropertyChanged
    {
        public Class2()
        {
        }
        private string textToBind;
        public string TextToBind { get { return textToBind; } set { SetProperty(ref textToBind, value); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
