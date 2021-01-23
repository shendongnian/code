        //update function
        void updateSection()
        {
            string cmdText = @"update deliver_assets 
                set Del_ASupplier =@sup.
                    Del_AName = @name,
                    Del_ABrand = @brand
                    Del_AQty = @qty
                    Del_AReceived = @recv
                 where Del_aID = @id";
            using(MySqlConnection con = new MySqlConnection(.....))
            using(MySqlCommand cmd = new MySqlCommand(cmdText, con))
            {
               cmd.Parameters.Add("@sup", MySqlDbType.VarChar).Value = SuppNameCombo.Text;
               cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = txtProdName.Text;
               cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value =  txtProdBrand.Text; 
               cmd.Parameters.Add("@qty", MySqlDbType.VarChar).Value = Convert.ToDouble(txtQty.Text);
               cmd.Parameters.Add("@recv", MySqlDbType.VarChar).Value = DTPReceived.Text;
               cmd.Parameters.Add("@id", MySqlDbType.Int32).Value =  Convert.ToInt32(lblAssetIDChecker.Text);
               con.Open();
               int rowsUpdated = cmd.ExecuteNonQuery();
               if(rowUpdated > 0)
                   MessageBox.Show("Record updated");
          }
       }
