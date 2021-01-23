        try
        {
            var connectionSb = new SqlConnectionStringBuilder("your CS");
        }
        catch(ArgumentException e)
        {
            //Connection string is not valid
        }
