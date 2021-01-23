    IEnumerator enum1 = ds.Tables.GetEnumerator();
    while (enum1.MoveNext())
    {
        IEnumerator enum2 = ((DataTable)enum1.Current).Rows.GetEnumerator();
        while (enum2.MoveNext())
        {
            temp_data = temp_data + ((DataRow)enum2.Current)[0];
        }
    }
