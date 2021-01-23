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
                     DbCommand _command = db.GetSqlStringCommand(iterator.Current.ToString());
                     IDataReader dataReader = db.ExecuteReader(_command);
        
                      dataDictionary.Add(iterator.Current.GetAttribute("name", ""), dataReader);
                 }
                  return dataDictionary;
           }
        }
