       private void ColorPicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                ColorPicker1.IsOpen = true;
            }
        }
