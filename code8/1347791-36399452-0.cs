    private void button_Click(object sender, RoutedEventArgs e) 
    {
            var dc = (sender as System.Windows.Controls.Button).DataContext;
            var cs1 = dc as Class1;
            cs1.TestProperty = "Test button";
    }
