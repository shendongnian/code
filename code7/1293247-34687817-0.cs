            string selectedValue = comboBox1.Text;
            if (string.IsNullOrEmpty(selectedValue))
            {
                MessageBox.Show("Please select something");
                return;
            }
            string sql = "UPDATE fixedBugs SET Success = Success + 1 WHERE Fixed_ID = @selectedValue";
            try
            {
                using (SqlCeCommand cm = new SqlCeCommand(sql, mySqlConnection))
                {
                    SqlCeParameter param = new SqlCeParameter("@selectedvalue", SqlDbType.NText);
                    cm.Parameters.Add(param);
                    cm.Parameters["@selectedvalue"].Size = 50;
                    cm.Parameters["@selectedvalue"].Value = selectedValue.Trim();
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
