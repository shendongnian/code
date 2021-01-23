    using( var dt = new DataTable() )
    {
        dt.Load( dataReader );
        foreach( DataColumn column in dt.Columns )
        {
            csv.WriteField( column.ColumnName );
        }
        csv.NextRecord();
    
        foreach( DataRow row in dt.Rows )
        {
            for( var i = 0; i < dt.Columns.Count; i++ )
            {
                csv.WriteField( row[i] );
            }
            csv.NextRecord();
        }
    }
    
