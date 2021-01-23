    DataTable userTable;
            DataTable ds;
            int cin;
            string nom;
            string prenom;
            Byte[] ImageByte;
            userTable = ds;
            if (userTable == null)
                return false;
            else
            {
                if (userTable.Rows.Count > 0)
                {
                    foreach (DataRow userRow in userTable.Rows)
                    {
                        cin = Convert.ToInt32(userRow["cin"]);
                        nom = userRow["nom"].ToString();
                        prenom = userRow["prenom"].ToString();
                        ImageByte = (Byte[])(userRow["image"]);
                    }
                }
            }
