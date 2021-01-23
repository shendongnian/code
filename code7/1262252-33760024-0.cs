    .
    .
    sqlCmd2.CommandType = System.Data.CommandType.Text;
    sqlCmd2.CommandText = string.Format("SELECT DisplayName FROM FormField WHERE EventId = 1 AND Visible = 0 ORDER BY ColumnOrder ASC;");
    int numberOfRecords;
    using (System.Data.DataTable dataTable =new System.Data.DataTable())
    {                    
         dataTable.Load(sqlCmd2.ExecuteReader());
         numberOfRecords = dataTable.Rows.Count;  
      
         for (int i = 0; i < dataTable.Rows.Count; i++)
         {
              System.Data.DataRow dr = dataTable.Rows[i];
              var PanelFormFields = new Panel();
              var LabelFormFields = new Label();
              var ListItemFormFields = new ListItem();
              LabelFormFields.Text = dr["DisplayName"].ToString();
              CheckBoxListFormFields.Items.Add(new ListItem(dr["DisplayName"].ToString(), "C"));
              PanelFormFields.Controls.Add(LabelFormFields);
              PanelFormFields.Controls.Add(CheckBoxListFormFields);
         }
    }
