    public MainWindow()
    {
       FillDataGrid();
    }
    private void FillDataGrid()
    {
       ObservableCollection<Person> coll = new ObservableCollection<Person>();
       for (int start = 0; start < 10; start++)
       {
           coll.Add(new Person() { IdPerson = start, Name = "Bill" + start.ToString(), SurName = "ONeill" });
       }
       dataGrid.ItemsSource = coll;
    }
