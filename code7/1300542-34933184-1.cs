        private void grdScheduler_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
          if (e.PropertyType == typeof(List<object>))
          {
            DynamicDataGridTemplateColumn dgTemplateCol = new DynamicDataGridTemplateColumn();
            dgTemplateCol.CellTemplate = (sender as DataGrid).FindResource("ListTemplate") as DataTemplate;
            dgTemplateCol.ColumnName = e.PropertyName;
            e.Column = dgTemplateCol;
          }
        }
      
