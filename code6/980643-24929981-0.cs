    StringBuilder sb = new StringBuilder();
    foreach(var item in clSiparisTipi.SelectedItems){
       sb.Append((String)item.Value)
         .Append(",");
    }
    // Remove trailing comma
    sb.Remove(sb.Length-1,1);
    string values = sb.ToString();
