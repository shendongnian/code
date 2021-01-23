            public string Message1
            {
                get { return (string)GetValue(Message1Property); }
                set { SetValue(Message1Property, value); }
            }
    
            // Using a DependencyProperty as the backing store for Message1.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty Message1Property =
                DependencyProperty.Register("Message1", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
    
             public string Message2
            {
                get { return (string)GetValue(Message2Property); }
                set { SetValue(Message2Property, value); }
            }
    
            // Using a DependencyProperty as the backing store for Message2.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty Message2Property =
                DependencyProperty.Register("Message2", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
    
   
            //an array of properties as combobox.Items
            public DependencyProperty[] AllowedProperties 
            { 
                get
                {
                    return new DependencyProperty[] { Message1Property, Message2Property };
                }
            }
    
            //selected property as combobox.selectedItem
            DependencyProperty _chosenProperty;
            public DependencyProperty ChosenProperty
            {
                get
                {
                    return _chosenProperty;
                }
                set
                {
                    _chosenProperty = value;
                    OnPropertyChanged("ChosenValue");
                }
            }
            
            //value of the selected property as textbox.text.
            public string ChosenValue
            {
                get
                {
                    return ChosenProperty == null ? string.Empty : (string)GetValue(ChosenProperty);
                }
            }
