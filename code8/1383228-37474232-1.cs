        // Create a datatable for your datagrid's source
        DataTable datatbl = new DataTable();
        datatbl.Columns.Add("startNode_ID", typeof(int));
        datatbl.Columns.Add("endNode_ID", typeof(int));
        // You can add new rows to datatable here
        for (int iCount = 1; iCount < MaximumRequiredCount; iCount++)
        {
            var row = datatbl.NewRow();
            row["startNode_ID"] = Your Start Node ID;
            row["endNode_ID"] = Your End Node ID;
            datatbl.Rows.AddRow(row);
        }
        DataGridView dataGrid1 = new DataGridView();
        dataGrid1.AutoGenerateColumns = true;
        dataGrid1.DataSource = datatbl;
