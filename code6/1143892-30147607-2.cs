    public List<DateTime> datetime { get; set; }
    
    public MyClass()
    {
      datetime = new List<DateTime>();
    
      // Add a DateTime:
      var newDateTime = DateTime.Now;
      datetime.Add(newDateTime);
    }
