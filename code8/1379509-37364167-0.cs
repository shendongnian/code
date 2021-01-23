    public class TimeLog : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // extra property for the selected project
        private Projects _selectedProjects 
        public Projects SelectedProjects
        {
            get 
            {
                if (_selectedProjects == null && _project.Any())
                {
                    _selectedProjects = _project.First();
                }
                return _selectedProjects;
            };
            set
            {
                 _selectedProjects = value;
                 OnPropertyChanged("_SelectedProjects");
            };
        }
        List<Projects> _project;
        
        // Ommited the rest
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
