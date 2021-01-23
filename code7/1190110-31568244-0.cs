    public IList<TModel> GetModel<T>(string query) where TModel : new()
    {
         var container = new List<T>();
         using(var connection = new SqlConnection(dbConnection))
              using(var command = new SqlCommand(query, connection))
              {
                   connection.Open();
                   using(var reader = command.ExecuteReader())
                      while(reader.Read())
                      {
                           TModel model = new TModel();
                           var type = model.GetType();
                           var table = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToArray();
    
                           foreach(var property in type.GetProperties())
                                foreach(var column in table)
                                     if(String.Compare(property.Name, column, true) == 0)
                                         if(!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                          property.SetValue(model, reader.GetValue(reader.GetOrdinal(property.Name)), null);
                           container.Add(model);
                      }
              }
    }
