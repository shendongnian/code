    You need to add following:
    
    private List<Optie> tempList= new List<Optie>();    
     public List<Optie> Options 
            {
                get
                {
                    return tempList;
                }
            }
    
    and remove following:
    
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
