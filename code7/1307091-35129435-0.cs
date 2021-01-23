        class MyObject : INotifyPropertyChanged, IDataErrorInfo
    {
        public MyObject()
        {
            stringEntry = "text";
            stringList = new string[] { "text1", "text2" };
        }
        private string[] stringList;
        public string[] StringList
        {
            get
            {
                return this.stringList;
            }
            set
            {
                if (this.stringList != value)
                {
                    this.stringList = value;
                    this.NotifyPropertyChanged("StringList");
                }
            }
        }
        private string stringEntry;
        public string StringEntry
        {
            get
            {
                return this.stringEntry;
            }
            set
            {
                if (this.stringEntry != value)
                {
                    this.stringEntry = value;
                    this.NotifyPropertyChanged("StringEntry");
                }
            }
        }
        public string Error
        {
            get
            {
                return null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public string this[string name]
        {
            get
            {
                string result = null; // I have a breakpoint here, it's never triggered
                                      // when I change the text in the StringList
                                      // It DOES work for the StringEntry though.
                switch (name)
                {
                    case "StringEntry":
                        if (string.IsNullOrEmpty(StringEntry))
                        {
                            result = "Entry cannot be emtpy";
                        }
                        break;
                    case "[(0)]": // works like this
                        if (string.IsNullOrEmpty(StringList[0]))
                        {
                            result = "Entry cannot be emtpy";
                        }
                        break;
                    case "StringList": // not required
                        if (string.IsNullOrEmpty(StringList[0]))
                        {
                            result = "Entry cannot be emtpy";
                        }
                        break;
                }
                return result;
            }
        }
        public string this[int index]
        {
            get { return StringList[index]; }
            set
            {
                StringList[index] = value;
            }
        }
    }
            <TextBox Grid.Column="1" Text="{Binding Path=[(sys:Int32)0], UpdateSourceTrigger=PropertyChanged, ValidatesOnDataErrors=True}" VerticalAlignment="Center" HorizontalAlignment="Stretch" Margin="5"/>
