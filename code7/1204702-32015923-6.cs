    foreach (var prop in props)
       {
          if (
                (prop.Name == "name1") 
                || (prop.Name == "name2"))
          {
             if (Convert.ToString(prop.GetValue(item, null)).Contains(search))
             {
                 newList.Add(item);
                 break;
             }
          }
       }
