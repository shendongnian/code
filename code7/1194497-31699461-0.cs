        private string selectedOption;
        public string SelectedOption
        {
            get
            {
                return this.selectedOption;
            }
            set
            {
                this.selectedOption = value;
                this.UpdateOnOptionChange();
            }
        }
       
        public List<string> Options
        {
            get;
            set;
        }
        public ObservableCollection<string> lst
        {
            get;
            set;
        }
        public MainViewModel()
        {
            this.Options = new List<string>() { "Fruits", "Vegetables" };
            this.lst = new ObservableCollection<string>();
        }
        private void UpdateOnOptionChange()
        {
            this.lst.Clear();
            if (this.selectedOption == "Fruits")
            {
                this.lst.Add("Apple");
                this.lst.Add("Banana");
                this.lst.Add("Pear");
            }
            else if (this.selectedOption == "Vegetables")
            {
                this.lst.Add("Carrot");
                this.lst.Add("Potato");
            }
           
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyOnPropertyChange(string astrPropertyName)
        {
            if (null != this.PropertyChanged)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(astrPropertyName));
            }
        }
    }
