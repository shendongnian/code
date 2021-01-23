    public class CustomCFactorItem : INotifyPropertyChanged
        {
            private string _field1 = "";
            public string Field1
            {
                get
                {
                    return _field1;
                }
                set
                {
                    _field1 = value;
                    RaisePropertyChanged("Field1");
                }
            }
            private string _field2 = "";
            public string Field2
            {
                get
                {
                    return _field2;
                }
                set
                {
                    _field2 = value;
                    RaisePropertyChanged("Field2");
                }
            }
            private string _field3 = "";
            public string Field3
            {
                get
                {
                    return _field3;
                }
                set
                {
                    _field3 = value;
                    RaisePropertyChanged("Field1");
                }
            }
            public CustomCFactorItem() { }
            public CustomCFactorItem(string field1, string field2, string field3)
            {
                this.Field1 = field1;
                this.Field2 = field2;
                this.Field3 = field3;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string property)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
