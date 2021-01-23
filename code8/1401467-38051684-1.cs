    var sb = new StringBuilder("...the basic query... where someColumn in (");
    int index = 0;
    var cmd = new SqlCommand(connection); // see also: "using"
    foreach(var title in titles) {
        if(index != 0) sb.Append(",");
        string name = "@title" + index++;
        sb.Append(name);
        cmd.Parameters.AddWithValue(name, value);
    }
    sb.Append(")");
    cmd.CommandText = sb.ToString();
    
