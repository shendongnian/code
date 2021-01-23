    using (IDbCommand selectCommand = this.createCommand(selectSQL))
    {
        //an exception or not will call Dispose() on selectCommand
        using (IDataReader theData = selectCommand.ExecuteReader())
        {
            //an exception or not will call Dispose() on theData
            while (theData.Read())
            {
                Phone aPhone = new Phone(...some code here...);
                thePhones.Add(aPhone);
            }
        }
    }
