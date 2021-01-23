    foreach(string val in values) {
    if(string.IsNullOrWhiteSpace(val)) {
    text+= val;
    }
       foreach(GlobalDataItem gdi in Globals.Tags.GlobalDataItems)
       {
          if (gdi.Name == val) 
          { 
             text+= gdi.Value; 
          } 
       }
    }
