    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image)
            {
                (sender as Image).Focus();
            }
        }
