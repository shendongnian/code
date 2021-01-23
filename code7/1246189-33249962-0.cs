    StringBuilder query = new StringBuilder();    
    query.Append("UPDATE  Warehouse SET usen = '");
    query.Append(value? "T" : "F");
    query.Append("' WHERE warehouse='");
    if(warehouse.Equals("T"))
    {
        query.Append(TWarehouse);
    }
    else if(warehouse.Equals("V"))
    {
        query.Append(VWarehouse);
    }
    else
    {
        query.Append("YourDefaultValue");
    }
    query.Append("'");
