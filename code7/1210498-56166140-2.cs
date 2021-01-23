    public static void trimData(DataSet ds)
    {
         foreach (DataTable t in ds.Tables)
           trimData(t);
    }
