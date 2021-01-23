    dataDictionary.Add(iterator.Current.GetAttribute("name", ""), reader);
    public override Dictionary<string, DbDataReader> GetData()
    {
        using (_connection)
        {
             Dictionary<string, DbDataReader> dataDictionary = new Dictionary<string, DbDataReader>();
             xmlDoc.Load("Queries.xml");
             XPathNavigator navigator = _xmlDoc.CreateNavigator();
             XPathNodeIterator iterator = navigator.Select("//query");
             while (iterator.MoveNext())
             {
                  _command = new SqlCommand(iterator.Current.ToString());
                  _command.Connection = _connection;
                  _command.CommandText = iterator.Current.ToString();
                  SqlDataReader reader = _command.ExecuteReader();
    
                  dataDictionary.Add(iterator.Current.GetAttribute("name", ""), reader);
             }
              return dataDictionary;
       }
    }
