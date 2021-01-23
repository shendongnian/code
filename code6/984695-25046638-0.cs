     private void addDefect()
        {
            try
            {
                NpgsqlConnection conn = Connection.getConnection();
                conn.Open();
                DefectType = cboDefectType.Text;
                ResDes = txtRefDes.Text;
                NpgsqlCommand cmd2 = new NpgsqlCommand("select * from \"Board\" where \"board_serial_number\" = :SerialNumber;", conn);
                cmd2.Parameters.Add(new NpgsqlParameter("SerialNumber", SerialNumber));
                NpgsqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    DefectBoardID = dr.GetInt64(0);
                    cmd2.Dispose();
                    dr.Dispose();
                    conn.Close();
                  
                }
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into \"Defect\"(\"defect_type\",\"ref_des\",\"board_id\")" +
                    "Values(:DefectType,:RefDes,:BoardID);", conn);
                
                
                cmd.Parameters.Add(new NpgsqlParameter("DefectType", DefectType));
                cmd.Parameters.Add(new NpgsqlParameter("RefDes", ResDes));
                cmd.Parameters.Add(new NpgsqlParameter("BoardID", DefectBoardID));
                
                int recordInserted = cmd.ExecuteNonQuery();
                if (recordInserted == 1)
                {
                    lblError.Text = "Defects Added to Board" + SerialNumber + "!";
                }
                else
                {
                    lblError.Text = "Defects were not added to Board" + SerialNumber + "!";
                }
                conn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
