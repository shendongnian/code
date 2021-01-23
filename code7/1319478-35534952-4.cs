    public Gender 
    {
        get { return gender; }
        set 
        {
            if(gender!=value) 
            {
                gender = value;
                OnChange("Gender");
            }
        }
    }
