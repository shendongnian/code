    public MyWindow(){
       //initialize window
       MyTable = new DataTable();
       f_Grid.ItemsSource = MyTable.DefaultView;
       //This fill MyTable 
    }
    protected void ClickEvent(object sender, RoutedEventArgs e)
    {
      Button button = sender as Button;
      object myobject = button.DataContext;
      // you row data in myobject
    }
