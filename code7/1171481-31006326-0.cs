    DataTable dt = dtContacts
        .AsEnumerable()
        .Where(c => 
            dicConditions.All(kv => c.Field<string>(kv.Key) == kv.Value)
        ).CopyToDataTable();
