    public class ButtonData : INotifyPropertyChanged
    {
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        ...
    }
