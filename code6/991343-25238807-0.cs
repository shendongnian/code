         string qry = ";";
         string query = "SELECT longitude,latitude FROM Gps_table  
    WHERE vehicle_no
    IN
    ( SELECT vehicle_no FROM User_table  WHERE username='" + userName + "' )
    
    "; 
        
         SqlCommand command = new SqlCommand(qry, dbConnection);
        
         if (reader.HasRows)
         {
             while (reader.Read())
             {
                 gpsTable.Rows.Add(reader["longitude"], reader["latitude"]);
             }
         }
        
         reader.Close();
         dbConnection.Close();
         return gpsTable;
