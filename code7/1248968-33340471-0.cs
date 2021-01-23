    private static void CurdOperation()
        {
            SqlCeConnection con = new SqlCeConnection("Data Source="
                + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "MyDB.sdf"));
            sda = new SqlCeDataAdapter();
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tblFees";
            sda.SelectCommand = cmd;
            SqlCeCommandBuilder cb = new SqlCeCommandBuilder(sda);
            sda.InsertCommand = cb.GetInsertCommand();
            sda.UpdateCommand = cb.GetUpdateCommand();
            sda.DeleteCommand = cb.GetDeleteCommand();
        }
        #endregion
    try
    {
         if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(cmbSex.Text) || string.IsNullOrEmpty(cmbFeesAmount.Text) || string.IsNullOrEmpty(cmbFeesStatus.Text) || string.IsNullOrEmpty(cmbSex.Text) || string.IsNullOrEmpty(Date.Text)) { MessageBox.Show("Please Input data."); return; }
             Update(lblDI.Text);
             Reset();
             this.BindGrid();
    }
    catch (Exception ex)
    {
         MessageBox.Show(ex.ToString());
    }
