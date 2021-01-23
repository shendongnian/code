         DataSet ds = new DataSet();
        DataTable dt;
        DataRow dr;
        DataColumn objstrError;
        DataColumn objBytearr;
        dt = new DataTable();
        objstrError = new DataColumn("strID", Type.GetType("System.String"));
        objBytearr = new DataColumn("strName", Type.GetType("System.String"));
        dt.Columns.Add(objstrError);
        dt.Columns.Add(objBytearr);
        dr = dt.NewRow();
        dr["strID"] = "1";
        dr["strName"] = "Britains got talent";
        dt.Rows.Add(dr);
        string json    =JsonConvert.SerializeObject(dt,Newtonsoft.Json.Formatting.Indented);
         normal intelisense gives:"[\r\n  {\r\n    \"strID\": \"1\",\r\n          \"strName\": \"Britains got talent\"\r\n  }\r\n]"
    using TextVisualizer if you see it then looks like this:[
    {
    "strID": "1",
    "strName": "Britains got talent"
     }
    ]
