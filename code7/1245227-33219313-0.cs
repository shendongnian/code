       interface IValid
        {
            bool Valid { get; set; }
        }
    
        class Canvas : IValid, INotifyPropertyChanged
        {
            private bool valid;
            public bool Valid
            {
                get { return this.valid; }
                set
                {
                    this.valid = value;
                    this.OnPropertyChanged("Valid");
    
                    this.SetPropertyValues(this);
                }
            }
    
    
            public Canvas()
            {
                this.Person = new Person();
            }
            
            public Person Person { get; set; }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            
            private void SetPropertyValues(IValid obj)
            {
                var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var property in properties)
                {
                    if (property.CanRead)
                    {
                        var validObject = property.GetValue(obj) as IValid;
    
                        if (validObject != null)
                        {
                            validObject.Valid = obj.Valid;
    
                            SetPropertyValues(validObject);
                        }
                    }
                }
            }
    
    
        }
        class Person : IValid, INotifyPropertyChanged
        {
            private bool valid;
            public bool Valid
            {
                get { return this.valid; }
                set
                {
                    this.valid = value;
                    this.OnPropertyChanged("Valid");
                }
            }
    
    
            public Person()
            {
                this.Age = new Age();
            }
    
            public Age Age { get; set; }
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        class Age : IValid, INotifyPropertyChanged
        {
            private bool valid;
            public bool Valid
            {
                get { return this.valid; }
                set
                {
                    this.valid = value;
                    this.OnPropertyChanged("Valid");
                }
            }
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
