    if( null != row.Cells[0].Value )
    {
        id = int.Parse(row.Cells[0].Value.ToString());
    }
    if(null != row.Cells[1].Value)
    {
        qty = int.Parse(row.Cells[1].Value.ToString());
    }
