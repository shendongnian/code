    public string Method(string value, int? number = null)
    {
        if(number.HasValue)
        {
            //DoWork with int
        }
        else
        {
            //Do work without int
        }
        return "result";
    } 
