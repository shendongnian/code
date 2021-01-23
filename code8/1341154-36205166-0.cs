     using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            while (sdr.Read())
            {
                ListItem item = new ListItem();
                item.Text = sdr["BarCodeGroupName"].ToString() + " " + sdr["BarCodeGroupDesc"].ToString();
                item.Value = sdr["BarCodeGroupName"].ToString();
                cmd.Parameters.AddWithValue("@BarCodeGroupName", BarCodeInit);
                BatchCode.Items.Add(item);
            }
        }
