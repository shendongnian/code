    public Thing Get(string id)
    {
        try
        {
            var model = new Thing(id);           
            return model;
        }
        catch
        {
            //throw not found exception
        }
    }
