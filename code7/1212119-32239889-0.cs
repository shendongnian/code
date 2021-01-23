    public PermanentEmployee(string Name, int ID, double WagPerAnnum)
    {
        this.Name = Name;
        this.ID = ID;
        // You want WagPerAnnum (the parameter)
        // and not WagePerAnnum (the property)
        this.WagePerAnnum = WagePerAnnum;
    }
