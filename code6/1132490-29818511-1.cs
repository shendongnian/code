    public void Trim()
    {
        Name = Trim( Name );
        Email = Trim( Email );
        // ...
    }
    
    private string Trim(string field )
    {
        if( ! String.IsNullOrEmpty( field ) )
            field = field.Trim();
        return field;
    }
