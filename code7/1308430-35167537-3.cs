    var buffer = new StringBuilder();
    buffer.Append("[");
    for(int i=1;i<=10;i++)
    {
       buffer.Append("[");
       foreach(var item in items)
       {       
          buffer.Append("\"\"");
          buffer.Append(item.Pro1);         
          buffer.Append("\"\"",");
           //add other props
       }
        buffer.Append("]");
    }
    buffer.Append("]");
    File.WriteAllText(path,buffer.ToString();
