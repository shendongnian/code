    Query = "Select [id],[Name],[Marks],[Grade] from [Sheet1$]";
    //Create OleDbCommand to fetch data from Excel
    OleDbCommand cmd = new OleDbCommand(Query, excelCon);
    //System.Data.OleDb.OleDbDataReader dReader;              
    DataSet ds = new DataSet();
    OleDbDataAdapter oda = new OleDbDataAdapter(Query, excelCon);
    excelCon.Close();
    oda.Fill(ds);
    DataTable Exceldt = ds.Tables[0];
    foreach (DataRow dr in Exceldt.Rows)
    {
       ExampleModel NewModel= new ExampleModel ();
       //Pass values to model whatever your model is.
       //Add to your dbContext
       dbContext.tableName.Add(NewModel);
       dbContext.SaveChanges();
    }
    return RedirectToAction("Import");
