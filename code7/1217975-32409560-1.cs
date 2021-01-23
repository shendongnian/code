    var selectCommand = this.createCommand(selectSQL);
    try
    {
        var theData = selectCommand.ExecuteReader();
        try
        {
            while (theData.Read())
            {
                Phone aPhone = new Phone(...some code here...);
                thePhones.Add(aPhone);
            }
        }
        finally
        {
            if (theData != null)
            {
                theData.Dispose();
            }
        }
    }
    finally
    {
        if (selectCommand != null)
        {
            selectCommand.Dispose();
        }
    }
