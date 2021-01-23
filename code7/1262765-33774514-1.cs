    private Data.Patient patient;
    public Data.Patient Patient
    {
         get { return patient; }
         set
         {
              patient = value;
              NotifyPropertyChanged(null); //informs view that all properties updated
         }
    }
