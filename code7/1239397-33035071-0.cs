    public int Salary
    {
        get
        {
            return salary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("salary", "wyplata ma byc wieksza niz 0");
            }
            else
            {
                salary = value;
            }
        }
    }
