    public class JobSearch : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public JobSearch()
        {
            JobSearchCommand = new JobSearchCommand();
        }
        public ICommand JobSearchCommand { get; private set; }
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
