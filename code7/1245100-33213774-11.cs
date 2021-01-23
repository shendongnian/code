    public static class CommandExtensions
    {
        public static IReadOnlyCollection<T> ToList<T>(this IDbCommand cmd, IDataMapper mapper)
        {
            using (var reader = cmd.ExecuteReader())
            {
                var items = new List<T>();
                while (reader.Read())
                {
                   var item= _mapper.Map(reader);
                   items.Add(item);
                }
                return item;
            }
        }
    }
