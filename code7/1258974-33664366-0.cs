    olpr.Add(dr[i].ToString());
     cn.Open();
     cmd.CommandText = "SELECT Code, Name, Price, Quantity FROM dbo.[Table]";
     SqlDataReader dr = cmd.ExecuteReader();
    
     var colna = new List<string>();
     var colpr = new List<string>();
     dr.Read(); // this will only read one row
     for (int i = 0; i < dr.FieldCount; i++)
     {
          colna.Add(dr.GetName());
          colpr.Add(dr[i].ToString());
     }
    
     string[] sna = colna.ToArray();
     string[] spr = colpr.ToArray();
    
     listBox2.Items.AddRange(sna);
     listBox3.Items.AddRange(spr);
