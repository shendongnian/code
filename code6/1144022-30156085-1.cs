    var maxLength = 0;
    foreach(DataColumn c in table.Columns)
    {
        //if the length of the column name is greater than the current max length
        //update the max length
        maxLength = maxLength < c.Name.Length ? c.Name.Length : maxLength;
    }
    //add some padding
    maxLength = maxLength + 2;
    
    var sb = new StringBuilder();
    
    //create the top row
    foreach(DataColumn c in table.Columns)
    {
       sb.AppendFormat("+{0}+", new String('-',maxLength));
    }
    sb.AppendLine();
    
    //create the column names
    foreach(DataColumn c in Table.Columns)
    {
       sb.AppendFormat("|{0}|", c.Name.PadLeft('0', maxLength));
    }
    sb.AppendLine();
    
    //create the bottom of the column headers same as the top
    foreach(DataColumn c in table.Columns)
    {
       sb.AppendFormat("+{0}+", new String('-',maxLength));
    }
    sb.AppendLine();
