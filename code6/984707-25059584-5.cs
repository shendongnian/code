    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        gridData.Add(new MyClass() { FirstName = "John", LastName = "Smith"  });
    }
    private void btnChange_Click(object sender, RoutedEventArgs e)
    {
        gridData[0].FirstName = "Meow Mix";
    }
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        //using List to use .ForEach less code to write and looks cleaner to me
        List<MyClass> remove = gridData.Where(x => x.LastName.Equals("Smith")).ToList();
        remove.ForEach(x => gridData.Remove(x));
    }
