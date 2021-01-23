      //Here come the function
       private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
       {
         //your test here to see if they match...
           DataRowView row = (DataRowView)e.Row.Item;
           String Content = row.Row[i].ToString();
           if(Content = //Did it matche something ?)
           { 
             //If yes:
              e.Row.Background = new SolidColorBrush(Color.FromArgb(255, 217, 77, 77));
             //or 
             e.Row.Background = Brushes.LightGreen;
           }
       } 
