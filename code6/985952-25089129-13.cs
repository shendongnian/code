    if (e.ColumnIndex == yourButtonColumnIndex )
    {
       Button btn = gradesDataGridView[yourButtonColumnIndex , e.RowIndex].Value as Button;
       if (btn != null) buttons_Click(btn, null);
    }
