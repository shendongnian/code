    if (e.ColumnIndex == yourButtonColumnIndex )
    {
       Button btn = gradesDataGridView[yourButtonColumnIndex , e.RowIndex].Value as Button;
       if (btn != null) 
       {
         var handler = (EventHandler)GetDelegate(btn, "EventClick");
         if (handler != null) btn.Invoke(handler);
       }
    }
