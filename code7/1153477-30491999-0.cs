    public string FirstName { get { return _firstName; }
                              set { _firstname = value; 
                                    PropertyChanged("IsFirstNameValid");
                                    PropertyChanged("FirstName");
                                  }
                            }
    
    public bool IsFirstNameValid { get { return Regex.IsMatch( FirstName,
                                                               ValidationPatternFirstName); }}
