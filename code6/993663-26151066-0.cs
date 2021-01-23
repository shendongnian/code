    foreach( var test in list )
    {
        foreach( var item in test.Data )
        {
            csvWriter.WriteField( item );
        }
    
        csvWriter.NextRecord();
    }
