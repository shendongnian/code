    System.Data.DataRowCollection DRC1 = dictionaries.GetData(constants.SQL_1);
    System.Data.DataRowCollection DRC2 = dictionaries.GetData(constants.SQL_2);
    foreach (System.Data.DataRow DR1 in DRC1)
    {
         DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)dgv[0, dgv.Rows.Count - 1];
         foreach (System.Data.DataRow DR2 in DRC2)
         {
             cmb.Items.Add(DRC2["fieldname2"].ToString().Trim());
         }
         cmb.Value = DRC1["fieldname1"].ToString();
    }
