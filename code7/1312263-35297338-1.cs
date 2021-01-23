      Dispatcher.Invoke((Action)(() => { 
           var dtgColumn = new DataGridTextColumn();
           dtgColumn.Header = "AAA"
    
           dtgResults.Columns.Add(dtgColumn); 
       }));
