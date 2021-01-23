        get
        {
             return LastName + ", " + FirstName;
        }
        set
        {
             string[] names = value.Split(", ");
             LastName = names[0];
             FirstName = names[1];
        }
    }
