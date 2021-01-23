    if (e.ColumnIndex == yourBottonColumnIndex )
    {
       Button btn = gradesDataGridView[yourBottonColumnIndex , e.RowIndex].Value as Button;
       if (btn != null) buttons_Click(btn, null);
    }
