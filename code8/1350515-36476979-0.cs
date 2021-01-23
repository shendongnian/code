    while (reader.Read())
    {
        for(int colNum = 0; colNum < 4; colNum++)
        {
            if (reader[colNum]!=DBNull.Value)
            {
                string playerToInform = reader.GetString(colNum).ToString();
                string informClientMessage = "ULG=" + clientIP + ","; //User Left Game
                byte[] informClientsMessage = new byte[informClientMessage.Length];
                informClientsMessage = Encoding.ASCII.GetBytes(informClientMessage);
                playerEndPoint = new IPEndPoint(IPAddress.Parse(playerToInform), 8001);
                clientSocket.SendTo(informClientsMessage, playerEndPoint);
            }
        }
    }
