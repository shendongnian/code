    if (Enable)
                    {
    
    
    
                        if (columnName == "IntegerGreater10Property" && this.IntegerGreater10Property < 10)
                        {
                            return "Number is not greater than 10!";
                        }
    
                        if (columnName == "DatePickerDate" && this.DatePickerDate == null)
                        {
                            return "No Date given!";
                        }
    
                        if (columnName == "FirstName")
                        {
                            if (string.IsNullOrEmpty(FirstName) || FirstName.Length < 3)
                                return "Please Enter  First Name";
                        }
                        if (columnName == "LastName")
                        {
                            if (string.IsNullOrEmpty(FirstName) || FirstName.Length < 3)
                                return "Please Enter Last Name";
                        }
                    }
                    return null;
