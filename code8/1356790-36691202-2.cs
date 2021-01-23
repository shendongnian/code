    public VehicleModels()
    {
        Options = new List<Optie>();
    }
    
    public void AddOption(Optie optie) {
        if (!Options.Equals(null))
        {
            Options.Add(optie);
        }  
    }
