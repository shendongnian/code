    {
        IEnumerator<DataRow> iter = table.Rows.GetEnumerator();
        // note this ^^^ is disposed after the loop if IDisposable; not shown
        while(iter.MoveNext())
        {
            DataRowView row = (DataRowView) iter.Current; // .Current is: DataRow
            // ...
        }
    }
