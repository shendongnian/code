    public object[] MapProperty(string key, Employee e)
    {
        switch (k) {
           case "Designation" : return e.Designation;
           case "DOB" : return e.Dob;
           // etc
        }
    }
    
