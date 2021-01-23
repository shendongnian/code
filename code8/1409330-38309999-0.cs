    private string _name; //or `private string name;` but I recommend underscore for private fields.
    public string Name{get; set;}
    public Person MyBoy{get; set;}
    public void OnPropertyChanged(string propertyName); //propertyChange and PropertyChanged has different meaning, so use the correct one
    public void SetError(string propertyName, string error){..} //parameter names key and value are useless, they say nothing about what the parameters actually are. 
