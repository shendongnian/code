    string query = "select * from produits where reference = @num";
    MySqlCommand cmd = new MySqlCommand(query, con);
    cmd.Parameters.Add("@num", MySqlDbType.Int).Value =  n; 
    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader())
    if (dt.Rows.Count > 0)
    {
        dg2.DataSource =dt;
    }
    else
    {
        MessageBox.Show("Aucun élément avec ce reférence a été trouvé !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
    }
