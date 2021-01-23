    public static void FillCollection(IList collection, DataTable dt)
    {
        collection.Clear();
        foreach (DataRow row in dt.Rows)
        {
            collection.Add(row[0].ToString());
        }
    }
    public static void FillComboBox(ComboBox cb, DataTable dt)
    {
        FillCollection( cb.Items, dt );
    }
    public static void FillComboBoxColumn(DataGridViewComboBoxColumn col, DataTable dt)
    {
        FillCollection( col.Items, dt );
    } 
