    private void popClass()
    {
        cmbClass.Items.Clear();
        DataSet ds = new DataSet();
        cmbClass.Items.Add("---Select----");
        string sqlPS = @"SELECT * FROM tblclass_msb";
        try
        {
            using (FbConnection conPS = new FbConnection(connectionString))
            {
                conPS.Open();
                using (FbCommand cmdPS = new FbCommand(sqlPS, conPS))
                {
                    using (FbDataAdapter da = new FbDataAdapter())
                    {
                        da.SelectCommand = cmdPS;
                        da.Fill(ds);
                        DataRow dr=da.Tables[0].NewRow();
                        dr["c_id"]=0;
                        dr["c_name"]="--Select--";
                        dt.Rows.InsertAt( dr,0);
                        cmbClass.DataSource = ds.Tables[0];
                        cmbClass.ValueMember = "c_id";
                        cmbClass.DisplayMember = "c_name";
                    }
                }
            }
        }
        catch (FbException ex)
        {
            MessageBox.Show("PC-->>" + ex.Message);
        }
    }
