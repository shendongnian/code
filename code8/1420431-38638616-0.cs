    private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button= sender as Button;    
             var obj =(YourModelHere)button.DataContext;
    
                List.Remove(obj);
         }
