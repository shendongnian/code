        private void OnButtonClickOdd(object sender, RoutedEventArgs e)
        {
            // Unsubscribe OnButtonClickOdd
            button.Click -= OnButtonClickOdd;
            
            // Subcribe to OnButtonClickEven
            button.Click += OnButtonClickEven;
    
            // Do your job here
        }
        private void OnButtonClickEven(object sender, RoutedEventArgs e)
        {
            // Unsubscribe OnButtonClickEven
            button.Click -= OnButtonClickEven;
            // Subcribe to OnButtonClickOdd
            button.Click += OnButtonClickOdd;
    
            // Do your job here
        }
