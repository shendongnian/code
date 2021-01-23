    try
    {
        String x;
        String y;
        String z;
        String SenderNumber, receiverNumber, message;
        SenderNumber = Request.QueryString.Get("sender");
        receiverNumber = Request.QueryString.Get("receiver");
        message = Request.QueryString.Get("msg");
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        connection.ConnectionString = Constring;
        command.Connection = connection;
        command.CommandText = "SELECT P_Name, P_Parking FROM tblPharmacy Where Code = '" + message + "'" ;
        connection.Open();
        reader = command.ExecuteReader();            
        String data = "";
        while (reader.Read())
        {
            x = reader["P_Name"].ToString();
            y = reader["P_Parking"].ToString();
            data += x + "  " + y + " - ";
        
        }
 
