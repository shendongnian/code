    public static T MapToList<T>(this DataTable dt) where T : class
    {
         Mapper.CreateMap<IDataReader, T>();
         var list = new List<T>();
         using (DataTableReader reader = dt.CreateDataReader())
         {
             do
             {
                 if (reader.HasRows)
                 {
                     list.Add(reader)
                 }
             } while (reader.NextResult());
         }
         return Mapper.Map<IDataReader, T>(list);
    }
