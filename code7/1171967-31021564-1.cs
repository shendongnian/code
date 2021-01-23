    public class DataItemFactory<T> where T : IDataItem, new()
    {
      private readonly DataTable m_Table;
      public DataItemFactory(DataTable table)
      {
        m_Table = table;
      }
      public T Create()
      {
        T result = default(T);
        if (m_Table.Rows.Count > 1)
        {
          result = new T();
          result.SetData(m_Table.Rows[0]);
        }
        return result;
      }
    }
