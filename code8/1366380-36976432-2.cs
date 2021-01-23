     public class State:INotifyPropertyChanged
        {
            public string State_Name { get; set; }
            public object State_Id { get; set; }
            bool isCheckBoxVisible;
            public bool IsCheckBoxVisible
            {
                get { return isCheckBoxVisible; }
                set
                {
                    if (value != isCheckBoxVisible)
                    {
                        isCheckBoxVisible = value;
                        OnPropertyChanged("IsCheckBoxVisible");
                    }
                }
            }
            public State(string name,object id,bool visibility=false)
            {
                State_Name = name;
                State_Id = id;
                IsCheckBoxVisible = false;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public override string ToString()
            {
                return State_Name;
            }
            void OnPropertyChanged(string propertyName)
            {
                // the new Null-conditional Operators are thread-safe:
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }  
          
