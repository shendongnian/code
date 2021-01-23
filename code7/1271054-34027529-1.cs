    class ViewModel1
    {
        private ObservableCollection<KeyValuePair<string, string>> myVar;
        public ObservableCollection<KeyValuePair<string, string>> MyProperty
        {
            get { return myVar; }
            set
            {
                if (//implement check if the new item needs to be pushed to the list here)
                {
                    myVar = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public void addNewEntry(KeyValuePair<string, string> newEntry)
        {
            MyProperty.Add(newEntry);
        }
        public void addNewEntryWithCheck(KeyValuePair<string, string> newEntry)
        {
            if (//implement check if the new item needs to be pushed to the list here)
            {
                MyProperty.Add(newEntry);
            }
        }
    }
