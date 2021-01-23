    private void btnStar_Click(object sender, RoutedEventArgs e)
        {
            if (btnclicked)
            {
                btnStar.Background = new SolidColorBrush(Colors.Yellow);              
                btnclicked = false;
            }
            else
            {
                btnStar.Background = new SolidColorBrush(Colors.Gray);//Gray
                btnclicked = true;
            }
