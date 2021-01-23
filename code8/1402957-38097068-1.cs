    //My dataTable to test , with 3 columns
            DataTable dt = new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Other");
            dt.Columns.Add("QuantityFromDB");
            //Add some  test data in my dataTable
            for(int i=0;i<15;i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i*2+"";
                dr[1] = "XX data XX";
                dt.Rows.Add(dr);
            }
         //Foreach row in your datatable ( your data )
        for(int y=0;y<dt.Rows.Count;y++)
            {
                //Get the value of the current "Model" Column value
                string currentModel = dt.Rows[y]["Model"].ToString();
                //make your request in the db to get the quantity
                int quantityfromdb = 50; //REQUEST
                //Update the value of the QuantityFromDB column for this model row
                dt.Rows[y]["QuantityFromDB"] = quantityfromdb;
            }
