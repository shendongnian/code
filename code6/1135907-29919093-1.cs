      private DataTable ConvertListToDataTable(List<WindowsFormsApplication1.ServiceReference1.ArrayOfString> list)
            {
                DataTable table = new DataTable();
                List<string> columnNames = list[0];
    
    
            for (int i = 0; i < columnNames.Count; i++)
            {
    
                table.Columns.Add(columnNames[i].ToString());
            }
    
            foreach (var array in list)
            {
                var NewRow = table.NewRow();
                for(int i = 0; i < columnNames.Count)
                {
                    NewRow[columnNames[i]] = array[i];
                }
                table.Rows.Add(NewRow);
            }
    
            return table;
    
        }
    
    
        List <WindowsFormsApplication1.ServiceReference1.ArrayOfString> list = cont.GetAllEmployee();
                       dataGridView.DataSource = ConvertListToDataTable(list);
                       dataGridView.DataBind();
