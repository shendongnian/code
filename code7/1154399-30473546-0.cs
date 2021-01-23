    SqlCommand command = new SqlCommand(updateString, db); 
    //command.Parameters.AddWithValue("@numdoc", NumDoc); 
    command.Parameters.AddWithValue("@kodprod", KodProd.Id); 
    command.Parameters.AddWithValue("@sorter", SorterKod); SqlDataReader 
    reader = command.ExecuteReader();
    if(reader.HasRows)
     while(reader.Read())//here error 
    { 
    Kol = reader["kol"].ToString(); 
    Adres = reader["adres"].ToString(); 
    NumWave = reader["numwave"].ToString(); 
    NumDoc = reader["numdoc"].ToString(); 
    } 
    reader.Close(); 
    }
    catch{}
