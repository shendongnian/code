    string x = "f0||Title Text||f1||Subtitle Text||f2||Option 1||f3||Option 2";
    string[] y = x.Split(new string[] { "||" }, StringSplitOptions.None);
    
    DataSet ds = new DataSet();
    DataTable dt = ds.Tables.Add();
    List<object> rowvalues = new List<object>(); //to hold the row values
    
    //Loop through 2 at a time,  
    for (int n = 0; n < y.Length; n = n + 2) 
    {
    	dt.Columns.Add(y[n]); //add the column
    	rowvalues.Add(y[n + 1]); //and save the value
    }
    
    //Create the row
    var dr = dt.NewRow();
    //Set the row values
    dr.ItemArray = rowvalues.ToArray();
