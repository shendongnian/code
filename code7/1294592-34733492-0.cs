    DataTable dtResult = table1.Clone(); // This will be empty at first
    var distinctRows = table1.DefaultView.ToTable(true, "ID").Rows.OfType<DataRow>().Select(k => k[0] + "").ToArray();
        
		   foreach (string id in distinctRows)
           {
               var rows = table1.Select("ID= '" + id + "'");
               string Name = "";
			   //string other = "";
               foreach (DataRow row in rows)
               {
				   
                   Name+= row["Name"] + ",";
				  // other += row["other"];
               }
               Name = Name.Trim(',');
 
               dtResult.Rows.Add(ID, Name)  // other);
               Name = "";
 			   //other = "";
			   
           }
 
           //var output = dtResult; 
		
		
		
			foreach(DataRow dr in dtResult.Rows)
			{
				Console.WriteLine(dr[0] + " --- " + dr[1]); // + "--- " + dr[2]);
			}
