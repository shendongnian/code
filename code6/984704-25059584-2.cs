    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        gridData.Add(new MyClass() { FirstName = "John", LastName = "Smith"  });
    }
    private void btnChange_Click(object sender, RoutedEventArgs e)
    {
        gridData[0].FirstName = "Meow Mix";
    }
