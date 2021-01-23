    for(int v = 0; v < dataGrid1.Rows.Count; v++)
    {
        if(string.Equals(dataGrid1[0, v].Value as string, "ITM-000001"))
        {
            dataGrid1.Rows.RemoveAt(v);
            v--; // this just got messy. But you see my point.
        }
    }
