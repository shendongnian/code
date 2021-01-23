    public DateTime? DATE     {
       get 
        {
        if (DATE.HasValue)
            return DATE;
        else
            return DateTime.Today;
        }
    }
