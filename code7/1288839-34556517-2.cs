        private void Category1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            // Check if you have something selected (this happens sometime)
            if(comboBox.SelectedIndex != -1)
            {
                // Take the text of the combo and build the path to the file
                string fileName = Path.Combine(@"C:\users", comboBox.Text + ".png"); 
                // Again, check if we really have that file available
                if(File.Exists(fileName))
                {
                    // Build a BitmapImage from the file
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(fileName, UriKind.Relative);
                    bi.EndInit();
                    // Set the Image for this combo. Not sure if the Stretch part is needed
                    CB1.Stretch = Stretch.Fill;
                    CB1.Source = bi3;
                } 
            }
        }
