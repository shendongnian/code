    public Dictionary<string, IDataReader> GetData()
        {
            using (_connection)
            {
                Dictionary<string, IDataReader> dataDictionary = new Dictionary<string, IDataReader>();
                _xmlDoc.Load("Queries.xml");
                XPathNavigator navigator = _xmlDoc.CreateNavigator();
                XPathNodeIterator iterator = navigator.Select("//query");
                while (iterator.MoveNext())
                {
                    _command = new SqlCommand(iterator.Current.ToString());
                    _command.Connection = _connection;
                    _command.CommandText = iterator.Current.ToString();
                    IDataReader reader = _command.ExecuteReader();
                    dataDictionary.Add(iterator.Current.GetAttribute("name", ""), reader);
                }
                return dataDictionary;
            }
        }
