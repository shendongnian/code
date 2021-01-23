        private void cell_MouseLeave(object sender, MouseEventArgs e)
        {
            TableCell tc = (TableCell)sender;
            SolidColorBrush brush = new SolidColorBrush(Colors.Green);
            tc.BorderBrush = brush;
            brush.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation(Colors.Silver, TimeSpan.FromSeconds(1)));
        }
