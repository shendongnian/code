    public string Species{ get; set;}
    public int Legs{ get; set;}
    public string Genus{ get; set;}
    public string IsExtinct { get; set;}
    public Animal (string species, int legs, string genus, bool isExtinct)
    {
        Species = species;
        Legs = legs;
        Genus = genus;
        IsExtinct = isExtinct;
    }
    public override string ToString()
    {
        string result = String.Format("{0} ({1} legged) {2}", Species, Legs, Genus);
        if(IsExtinct )
            result += " (extinct)";
  
        return result;
    }
