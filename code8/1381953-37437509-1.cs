    if(Property.Type == AllowedTyoes.String)
    {
        string stringval = Property.Value as string;
        //use the string for a string safe function
    }
    if(Property.Type == AllowedTyoes.Int)
    {
        string stringval = Property.Value as string;
        int tmp;
        if(int.TryParse(stringval,out tmp))
        {
            //use the string for a string safe function
        }
    }
