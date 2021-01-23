    private void Button1_Click(object sender, RoutedEventArgs e)
    {
       if(boundlist=="Employee")
       {
        List<Employee> copy = new List<Employee>
        ((myDataGrid.ItemsSource as IList).OfType<Employee>());
        this.Paginate<Employee>(copy,3,1);
       }
       else if(boundlist=="Student")
       {
        List<Student> copy = new List<Employee>
        ((myDataGrid.ItemsSource as IList).OfType<Student>());
        this.Paginate<Student>(copy,3,1);
       }
    }
