    public PlayerStats()
    {
        fields.Add("Health", value);
        // other fields here 
    }
    public void SetField(string name, float value)
    {
         if(!fields.ContainsKey(name))
             throw new InvalidOperationException("Field doesnt exists");
         fields[name] = value;
    }
