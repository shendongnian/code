    [XmlElement("TRAN_DATE")]
    public string? stringAuthDate { get; set; }
    
    [XmlIgnore]
    public DateTime AuthDate
    {
      get
      {
        DateTime dt;
        if (stringAuthDate.HasValue && DateTime.TryParse(stringAuthDate.Value, out dt))
          return dt;
        else
          return DateTime.MinValue;
      }
      set
      {
        stringAuthDate = value.ToShortDateString();   
      }
    }
