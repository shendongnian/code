        void comboboxadd()
        {
            SqlConnection cnn = new SqlConnection(global::BeautyShop.Properties.Settings.Default.BeautyMaConnectionString);
            cnn.Open();
            SqlCommand cmm = new SqlCommand("select SupName from MPham group by SupName order by SupName asc", cnn);
            try
            {
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    //Check here if item does not exist then add it.
                    if(!comboBox2.Items.Contains(dr["SupName"]))
                       comboBox2.Items.Add(dr["SupName"]);
                }
                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
