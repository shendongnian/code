    public void Trim()
    {
        Name = Trim(Name);
        Email = Trim(Email);
        // ...
    }
    
    private static void Trim(string field)
    {
        if( ! String.IsNullOrWhiteSpace( field ) )
        {
            field = field.Trim();
        }
    
        return field;
    }
