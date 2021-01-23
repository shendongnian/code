    public static string[] Record
    {
        get
        {
            if (record == null)
            {
                record = new string[1000];
            }
            return record;
        }
    }
