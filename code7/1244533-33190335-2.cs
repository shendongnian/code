     You need a Serializer to convert from DataTable to JSON - one such  
     Serializer is Newtonsoft.Json, download it from NuGet.
     using Newtonsoft.Json;
     Code:
     var oTable1 = JsonConvert.SerializeObject(dt1);
     var oTable2 = JsonConvert.SerializeObject(dt2);
     //Send back oTable1 and oTable2 to browser, choose your own way, e.g. 
     //Response.Write(oTable1);
     //Other way: Drag and drop two textbox(s) or two hiddenfield(s)
     TextBox1.Text = oTable1;
     TextBox2.Text = oTable2;
     Or
     HiddenField1.Value = oTable1;
     HiddenField2.Value = oTable2;
