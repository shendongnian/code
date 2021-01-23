    private DateTime _departureDate
    public DateTime DepartureDate
    {
      get
      {
         return _departureDate == DateTime.MinValue ? DateTime.Now : _departureDate; 
          
      }
    
      set
      {
        _departureDate = value;
      }
    }
