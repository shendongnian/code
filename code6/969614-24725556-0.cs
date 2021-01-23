    //Build html strin from all propeties
    PropertyInfo[] properties = yourObject.GetType().GetProperties();
    
    string lbl = "<label>{0}</label>";
    string value= "<span>{0}</span>";
    string tab ="\t";
    StringBuilder sb = new StringBuilder();
    
    foreach (PropertyInfo pi in properties)
    {
    
        var label = string.Format(lbl,pi.Name);
        var val =  string.Format(value, pi.GetValue(yourObject, null))
        sb.Append(label+tab+val);
        sb.Append("<br/>")    
        
    }
    Response.Write(sb.ToString()); 
