        private void rectangle_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Change this colour to whatever colour you want.
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            System.Windows.Shapes.Rectangle rect = (System.Windows.Shapes.Rectangle)sender;
            rect.Fill = mySolidColorBrush;
        }
