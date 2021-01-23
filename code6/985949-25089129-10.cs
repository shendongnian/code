    if (e.ColumnIndex == yourBottonColumnIndex )
    {
       Button btn = gradesDataGridView[yourBottonColumnIndex , e.RowIndex].Value as Button;
       if (btn != null) 
       {
         var handler = (EventHandler)GetDelegate(btn, "EventClick");
         if (handler != null) btn.Invoke(handler);
       }
    }
