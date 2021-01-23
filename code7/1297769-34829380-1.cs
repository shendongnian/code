    var pageSize = 10;
    var startAt = 0;
    
    while(true) 
    {
        using (SqlCommand sqlCommand = new SqlCommand(sql))
        {
            sqlCommand.Parameters.Add("@start", SqlDbType.Int).Value = startAt;
            sqlCommand.Parameters.Add("@pageSize", SqlDbType.Int).Value = pageSize;
            
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
            {
                using (DataTable dataTable = new DataTable())
                {
                    dataAdapter.Fill(dataTable);
    
                    var rowCount = dataTable.Rows.Count;
                    var startAt = startAt + rowCount;
    
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            /*Resize the image and again update those resized image to the same database table*/
                        }
                    }
                    else 
                    {
                        break;
                    }
                }
            }
        }
    }
