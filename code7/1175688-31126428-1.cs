     private void Form1_Load(object sender, EventArgs e)
            {
                LoadDataEntryScreenDATA();
            }
    
            public void LoadDataEntryScreenDATA()
            {
                //Displays DataGrid data
                SqlDataAdapter adap = new SqlDataAdapter("select EmployeeID, EmployeeName, EmployeeAge from Employee", SessionInfo.con);
                DataSet ds = new System.Data.DataSet();
                adap.Fill(ds);
                dataGridView_EmployeeList.DataSource = ds.Tables[0];
            }
    
            private void picImage_Click(object sender, EventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = @"C:\";
                dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                dlg.Title = "Select Firearm Picture.";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string picLoc = dlg.FileName.ToString();
                    picboxEmployeePic.ImageLocation = picLoc;
                }
            }
    
            private void btnSave_Click(object sender, EventArgs e)
            {
                byte[] imgData = File.ReadAllBytes(this.picboxEmployeePic.ImageLocation);
    
                SqlCommand insertCommand = new SqlCommand("spSaveImage", SessionInfo.con);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SessionInfo.con.Open();
    
                SqlParameter sqlParam1 = insertCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
                sqlParam1.Direction = ParameterDirection.Input;
                sqlParam1.Value = this.txtEmployeeName.Text;
                SqlParameter sqlParam2 = insertCommand.Parameters.Add("@EmployeeAge", SqlDbType.Int);
                sqlParam2.Direction = ParameterDirection.Input;
                sqlParam2.Value = Convert.ToInt32(this.txtEmployeeAge.Text);
                SqlParameter sqlParam3 = insertCommand.Parameters.Add("@EmployeePic", SqlDbType.VarBinary);
                sqlParam3.Direction = ParameterDirection.Input;
                sqlParam3.Value = imgData;
    
                SqlDataReader rd = insertCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (rd.Read())
                {
    
                }
                MessageBox.Show("New Employee added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SessionInfo.con.Close();
                LoadDataEntryScreenDATA();
            }
    
            private void dataGridView_EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView_EmployeeList.Rows[e.RowIndex];
    
                    txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                    txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
                    txtEmployeeAge.Text = row.Cells["EmployeeAge"].Value.ToString();
                    
                    string QueryImage = "select EmployeePic from Employee where EmployeeID='" + row.Cells["EmployeeID"].Value.ToString() + "'";
                    SqlCommand cmdDataBaseImage = new SqlCommand(QueryImage, SessionInfo.con);
                    SqlDataReader ReaderImage;
                    try
                    {
                        SessionInfo.con.Open();
                        ReaderImage = cmdDataBaseImage.ExecuteReader();
                        while (ReaderImage.Read())
                        {
                            byte[] data = (byte[])ReaderImage[0];  //(byte[])ReaderImage["EmployeePic"];
                            using (MemoryStream ms = new MemoryStream(data))
                            {
                                picboxEmployeePic.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        SessionInfo.con.Close();
                    }
                }
            }
    
            private void btnUpdate_Click(object sender, EventArgs e)
            {
                byte[] imgData = File.ReadAllBytes(this.picboxEmployeePic.ImageLocation);
    
                SqlCommand insertCommand = new SqlCommand("spUpdateImage", SessionInfo.con);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SessionInfo.con.Open();
    
                SqlParameter sqlParam1 = insertCommand.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50);
                sqlParam1.Direction = ParameterDirection.Input;
                sqlParam1.Value = this.txtEmployeeName.Text;
                SqlParameter sqlParam2 = insertCommand.Parameters.Add("@EmployeeAge", SqlDbType.Int);
                sqlParam2.Direction = ParameterDirection.Input;
                sqlParam2.Value = Convert.ToInt32(this.txtEmployeeAge.Text);
                SqlParameter sqlParam3 = insertCommand.Parameters.Add("@EmployeePic", SqlDbType.VarBinary);
                sqlParam3.Direction = ParameterDirection.Input;
                sqlParam3.Value = imgData;
                SqlParameter sqlParam4 = insertCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
                sqlParam4.Direction = ParameterDirection.Input;
                sqlParam4.Value = Convert.ToInt32(this.txtEmployeeID.Text);
    
                SqlDataReader rd = insertCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (rd.Read())
                {
    
                }
                MessageBox.Show("Employee Information Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SessionInfo.con.Close();
                LoadDataEntryScreenDATA();
            }
