        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MyInputDialog();
            if(dialog.ShowDialog()== true)
            {
                var input = dialog.tbResult.Text;
            }
        }
