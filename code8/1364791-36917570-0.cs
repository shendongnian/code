    public void Concour_LoadRowDetails (object sender, DataGridRowDetailsEventArgs e)
        {
            Eprv = e.DetailsElement.FindName("Epreuve") as DataGrid;
            MessageBox.Show("Epreuve Loaded");
            DataTable dt = new DataTable();
            dt = ((DataView)Concours.ItemsSource).ToTable();
            List<String> L = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                L.Add((String)row[0]);
            }
            int row_number = Concours.SelectedIndex;
            //Connect To DataBase (gestion_concour)
            MessageBox.Show(L[row_number]);
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "gestion_concour";
            MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            //Fill Epreuve 
            String q = "SELECT * FROM gestion_Concour.Epreuve WHERE Concour_Code = @Code";
            MySqlCommand cmd = new MySqlCommand(q, connection);
            cmd.CommandText = q;
            cmd.Parameters.AddWithValue("@Code", L[row_number]);
            cmd.ExecuteNonQuery();
            MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
            DataTable DS = new DataTable();
            DA.Fill(DS);
            Eprv.ItemsSource = DS.DefaultView;
            DA.Update(DS);
            connection.Close();
        }
