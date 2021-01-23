    [Serializable]
        public class ClientModel
        {
            private string firstName;
            private string middleName;
            private string lastName;
            private DateTime dateOfBirth;
            private string ssn;
            private string address;
            private string phone;
    
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #region Name Properties
            public string FirstName {
                get { return firstName; }
                set {
                    if (firstName != value)
                    {
                        firstName = value;
                        OnPropertyChanged("FirstName");
                    }
                }
            }
            public string MiddleName {
                get { return middleName; }
                set {
                    if (middleName != value)
                    {
                        middleName = value;
                        OnPropertyChanged("MiddleName");
                    }
                }
            }
            public string LastName {
                get { return lastName; }
                set {
                    if (lastName != value)
                    {
                        lastName = value;
                        OnPropertyChanged("LastName");
                    }
                }
            }
            #endregion
    
            public DateTime DateOfBirth {
                get { return dateOfBirth; }
                set {
                    if (dateOfBirth != value)
                    {
                        DateTime dt = Convert.ToDateTime(value); //This will probably need to revisited since DateTime objects are fucking stupid
                        dateOfBirth = dt.Date;
                        OnPropertyChanged("DateOfBirth");
                    }
                }
            }
    
            public string SSN {
                get { return ssn; }
                set {
                    if (ssn != value)
                    {
                        ssn = value;
                        OnPropertyChanged("SSN");
                    }
                }
            }
    
            public string Address {
                get { return address; }
                set {
                    if (address != value)
                    {
                        address = value;
                        OnPropertyChanged("Address");
                    }
                }
            }
    
            public string Phone {
                get { return phone; }
                set {
                    if (phone != value)
                    {
                        phone = value;
                        OnPropertyChanged("Phone");
                    }
                }
            }
    
        }
