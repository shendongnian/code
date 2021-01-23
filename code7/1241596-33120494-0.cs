    int _rowIndex = -1;
    bool _edited = false;
    .
    .
    .
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0) // it is button - column Action
        {
            if (_rowIndex >= 0) // not first editing
            {
                if (_rowIndex != e.RowIndex) // row change - cancel and begin elsewhere
                {
                    // TODO: ask for save edited values
                    endInlineEdit(_rowIndex);
                    beginInlineEdit(e.RowIndex);
                }
                else // the same row
                {
                    if (_edited) // is edited, so save
                    {
                        saveToDB(e.RowIndex);
                    }
                    else // repeating same row editation
                    {
                        beginInlineEdit(e.RowIndex);
                    }
                }
            }
            else // editing first time
            {
                beginInlineEdit(e.RowIndex);
            }
        }
    }
    private void saveToDB(int rowIndex)
    {     
        save to DB
        ...
        endInlineEdit(rowIndex);
    }
    private void beginInlineEdit(int rowIndex)
    {
        dataGridView1.Rows[rowIndex].Cells[0].Value = "Save";
        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells["FirstEditedColumn"];
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        dataGridView1.BeginEdit(true);
        _rowIndex = rowIndex;
        _edited = true;
    }
    private void endInlineEdit(int rowIndex)
    {
        dataGridView1.Rows[rowIndex].Cells[0].Value = "Edit";
        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        dataGridView1.EndEdit();
        _edited = false;
    }
    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        if (_edited)
        {
            endInlineEdit(_rowIndex);
        }
    }
