    public Boolean Manipulate(String Text) {
        try {
            MySqlConnection con = new MySqlConnection ("Connection String");
            MySqlCommand cmd = con.CreateCommand(); 
            con.Open();
            cmd.CommandText = Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i > 0;
        }
        Catch(Exception ex) {
            return false;
        }
     }
