    using (IDbCommand selectCommand = this.createCommand(selectSQL))
    {
        using (IDataReader theData = selectCommand.ExecuteReader())
        {
          while (theData.Read())
          {
            Phone aPhone = new Phone(...some code here...);
            thePhones.Add(aPhone);
          }
        }
    }
