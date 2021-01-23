    public static class DataRowExtensions
    {
        public static int ToInt(this DataRow row, int index)
        {
              return Convert.ToInt32(row[index].ToString());   
        }
    }
