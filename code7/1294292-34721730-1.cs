    public IList Paginate(IList list, int itemsPerPage, int currentPage)
    {
        // some code
    }
    private void Button1_Click(object sender, RoutedEventArgs e)
    {            
        this.Paginate(myDataGrid.ItemsSource as IList, 3, 1);
    }
