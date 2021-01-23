    public class Vraag : INotifyPropertyChanged
    {
        public List<string> antwoorden { get; set; }
        public string vraag { get; set; }
        private bool isChecked;
        public bool getChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
