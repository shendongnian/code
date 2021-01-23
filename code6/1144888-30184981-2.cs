    public string selectedStatus
        {
            get { return _selectedStatus; }
            set 
            {
                _selectedStatus = value; NotifyPropertyChanged("selectedStatus");
                if (selectedStatus == "Tree")
                {
                    SampleListData = new ObservableCollection<dynamic>();
                    SampleListData.Add(new Tree { name = "Mohan", age = 25 });
                    SampleListData.Add(new Tree { name = "Tangella", age = 28 });
                }
                if (selectedStatus == "Car")
                {
                    SampleListData = new ObservableCollection<dynamic>();
                    SampleListData.Add(new Car { name = "Mohan", horsePower=68,model = 1 });
                    SampleListData.Add(new Car { name = "Mohan", horsePower = 72, model = 1 });
                }
                if (selectedStatus == "Animal")
                {
                    SampleListData = new ObservableCollection<dynamic>();
                    SampleListData.Add(new Animal { name = "Tiger", genome="H" });
                    SampleListData.Add(new Animal { name = "Lion", genome="FG" });
                }
            }
        }
 
