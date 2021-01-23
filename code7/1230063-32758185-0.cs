    using Microsoft.Office.Interop.Access.Dao;
      var dbe = new DBEngine();
            var db = dbe.OpenDatabase(@"C:\access\mydb.accdb");
     //Initialize the properties 
            Dao.Property VERSION_PROPERTY = null;
     //Fill them with values
            VERSION_PROPERTY = db.CreateProperty("VERSION_PROPERTY",   Dao.DataTypeEnum.dbText, "Hello There. I am property of the database", true);
            //And append them
            db.Properties.Append(VERSION_PROPERTY); 
