    int index = -1;
    foreach (DataGridViewColumn col in Specialization_DataGridView.Columns)
    {
        if (col.HeaderText == "delete")
        {
            index = col.Index;
            break;
        }
    }
