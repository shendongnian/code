    Dictionary<string, string> resultDictionary = dataTable.Rows.OfType<System.Data.DataRow>()
        .Select( s => 
            new
            {
                Error = s["Error"] as string,
                Right = s["Right"] as string
            }
            ).ToDictionary( k => k.Error, v => v.Right );
