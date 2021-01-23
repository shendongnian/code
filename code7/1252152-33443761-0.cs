        public class AccountData : INotifyPropertyChanged
        {
            public AccountData(bool check, string accountName, int id, int forms, int pending, int archived, int total)
            {
                AccountName = accountName;
                Id = id;
                Forms = forms;
                Pending = pending;
                Archived = archived;
                Total = total;
                Checked = check;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            ........
            .........  
        }
