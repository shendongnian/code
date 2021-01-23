    public void properColumnValue(object columnValue)
    {
        Type[] types = new[] {typeof (int), typeof (decimal), typeof (long)};
 
        bool b = types.Any(x => x.IsInstanceOfType(columnValue));
        if (b)
        {
            // do stuff
        }
    }
