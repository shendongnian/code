    Private void RemoveRow()
      {
       for(int i = dtTable.Rows.Count-1; i >= 0; i--)
       {
       DataRow dr = dtTable.Rows[i];
       if (dr["name"] == comboBox1.Text) // name is the column name
        dr.Delete();
       }
      }
