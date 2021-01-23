    public int Import(string path)
    {
       try
       {
          string cmd = "LOAD DATA INFILE '" + path + "' INTO TABLE zen_hardware.products FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n'";
          int a = MySqlHelper.ExecuteNonQuery(conn.Connect(),cmd);
          return a;
       }
       catch
       {
          return -1;
       }
    }
