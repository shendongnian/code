    public MyWindow(){
       //initialize window
       MyTable = new DataTable();
       f_Grid.ItemsSource = MyTable.DefaultView;
       //This fill MyTable 
    }
    protected void ClickEvent(object sender, RoutedEventArgs e)
    {
      Button button = sender as Button;
      DataRowView myobject = button.DataContext AS DataRowView;
      if (myobject!=null)
      {
        // you row data in myobject[columnName]
      }
    }
