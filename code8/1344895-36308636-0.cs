           int id;
           string strSelect = "";
           strSelect = "SELECT ID FROM Database.Table WHERE TEXT = @TEXT;";       
           using(DB2Command cmdSelectID = new DB2Command(strSelect, db2Connection))
       {
           cmdSelectID.Parameters.Add("@TEXT", "strWrongText"); 
           using(DB2DataReader dr = cmdSelectID.ExecuteReader())
        {
            while(dr.Read())
          {
             id = (int)dr["ID"];
          }
        }
       }
