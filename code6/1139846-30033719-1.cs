    public ActionResult ConnexionBD()
        {
            SqlCeConnection cnx = new SqlCeConnection(@"Data Source=C:\Users\Antoine\Documents\Visual Studio 2012\Projects\Application\Application\App_Data\Database1.sdf");
            cnx.Open();
            SqlCeCommand cmd = new SqlCeCommand
            {
                CommandText = "INSERT INTO Objet VALUES(1,'F'," + DateTime.Now + ",'Moi'",
                CommandType = CommandType.Text,
                Connection = cnx
            };
            cmd = new SqlCeCommand {CommandText = "SELECT * FROM Objet", CommandType = CommandType.Text, Connection = cnx};
            SqlCeDataReader r = cmd.ExecuteReader();
            String chaine = "";
            while (r.Read())
            {
                string nom = (string)r["Nom"];
                string date = (string)r["Date"];
                string user = (string)r["User"];
                chaine += nom + "\t" + date + "\t" + user + "\n";
            }
            cnx.Close();
            return View(chaine);
        }
