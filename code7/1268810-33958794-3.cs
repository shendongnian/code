    DataTable dtMovieDetails = LoadDataTableFromXML(Server.MapPath("xml file path"));
    string[,] data = new string[dtMovieDetails.Rows.Count,dtMovieDetails.Columns.Count]; /*dtMovieDetails.Rows.Count represents number of Rows and dtMovieDetails.Columns.Count represents number of Columns in your xml file*/
    
    int row = 0; /* row counter */
    foreach (DataRow dataRow in dtMovieDetails.Rows)
    {
       for(int col = 0; col < dataRow.ItemArray.Count(); col++) /*col is columns counter */
       { 
         data[row, col] = dataRow[col].ToString(); 
       }
       row++;
    }
