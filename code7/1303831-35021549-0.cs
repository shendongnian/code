    static class RoomObjects
    {
        public static string buildObjects(int roomid)
        {
            string pList = "";
            MySqlDataReader mysqlRead = DBManager.database.getCommand("SELECT * FROM `objects` WHERE `roomid` = " + roomid + "").ExecuteReader();
    
            while(mysqlRead.Read())
            {
                pList += mysqlRead["id"].ToString() + (char)8 + mysqlRead["sprite"].ToString() + (char)8 + mysqlRead["x"].ToString() + (char)8 + mysqlRead["y"].ToString() + (char)8 + mysqlRead["z"] + (char)8 + mysqlRead["rotation"] + (char)8;
    
                pList += "," // to separate the values.
            }
    
            DBManager.database.closeClient();
    
            return pList;
        }
