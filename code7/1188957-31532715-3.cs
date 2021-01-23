        private void OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    myGrid.ItemsSource = System.IO.Directory.GetFiles(dialog.SelectedPath);
                }
            }
        } 
