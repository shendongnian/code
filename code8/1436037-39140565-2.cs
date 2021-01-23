     DataTable dt = new DataTable();
     dt.Clear();
     dt.Reset();
     con.Close();
     adaptors1.SelectCommand = con.CreateCommand();
     adaptors1.SelectCommand.CommandText = "Select TOP 1 [ponumber],[clref]  from [ISSPandayan].[dbo].[" + branch.Text + "] where [ponumber] = '" + dr.Cells["ponumber"].Value + "' ORDER BY [clref] ASC";
     adaptors1.Fill(dt); 
     // select query para malam kung existing ponumber
     if (dt.Rows.Count == 1)
     {
         adaptorss.InsertCommand.Parameters.Add("@already", SqlDbType.VarChar).Value = dt.Rows[0][1].ToString();
     }
     else
     {
         adaptorss.InsertCommand.Parameters.Add("@already", SqlDbType.VarChar).Value = " ";
     }
     //adaptorss.InsertCommand.Parameters.Add("@already", SqlDbType.VarChar).Value = "";
    
     //MessageBox.Show(Convert.ToString(dr.Cells["description"].Value));
     con.Close();
     con.Open();
     adaptorss.InsertCommand.ExecuteNonQuery();
     adaptorss.InsertCommand.Parameters.Clear();
