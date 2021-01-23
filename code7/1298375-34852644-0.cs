    string[] values = headerData.Split(new string[] { "<#Tag(", ")>" }, StringSplitOptions.None);
    string text = "";
    string val1 = "";
    
    var updatedValues = new List<string>();
    for (int i = 0; i < values.Length; i++ )
    {
        if(values[i] != string.Empty)
        {
            updatedValues.Add(values[i] + values[i + 1]);
            i++;
        }
    }
    
    foreach (string val in updatedValues) 
    {
       foreach(GlobalDataItem gdi in Globals.Tags.GlobalDataItems)
       {
          if (gdi.Name == val) 
          { 
             text+= gdi.Value; 
          } 
       }
    }
    MessageBox.Show(text); // 102030
    }
