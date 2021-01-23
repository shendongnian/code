    using (SqlDataReader reader = cmd.ExecuteReader())
        {
          List<userinfo> infoList = new List<userinfo>();
          while (reader.Read())
          {
            userinfo info = new userinfo();
            info.userid = reader.GetInt32(0);
            info.username = reader.GetValue(1).ToString();
            info.password = reader.GetValue(2).ToString();
            info.firstname = reader.GetValue(3).ToString();
            info.lastname = reader.GetValue(4).ToString();
            info.dob = reader.GetValue(5).ToString();
            info.dateregistered = reader.GetValue(6).ToString();
            infoList.Add(info);
            
      }
      var jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
      string jsonString = jsonSerialiser.Serialize<(infoList);
      System.IO.File.WriteAllText(@"D:\userlist.json", jsonString);
    }
