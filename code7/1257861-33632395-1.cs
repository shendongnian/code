              string sqlText = "create table pub(id int not null);";//----  OK ----
            //string sqlText = "EXECUTE BLOCK AS BEGIN \ncreate table pub(id int not null);\nalter table pub add primary key (id);\nEND";//----  FAILED  ----
            //string sqlText = "EXECUTE BLOCK AS BEGIN \nupdate jizda set cislovozidla = 99999 where cislovozidla = 999899;\nalter table pub add primary key (id);\nEND";//----  FAILED ----
            //string sqlText = "EXECUTE BLOCK AS BEGIN \nupdate jizda set cislovozidla = 99999 where cislovozidla = 999899;\nupdate jizda set cislovozidla = 99999 where cislovozidla = 99989;\nEND";//----  OK ----
            using (FbConnection dbConnection = new FbConnection(Program.ConnectDBData()))
            {
              dbConnection.Open();
              FbCommand cmd = new FbCommand(sqlText);
              cmd.CommandType = CommandType.Text;
              cmd.Connection = dbConnection;
              cmd.ExecuteNonQuery();
            }
