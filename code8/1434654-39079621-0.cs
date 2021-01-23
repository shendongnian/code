        private void load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".mp3";
            ofd.Filter = "All|*.*";
            ofd.Multiselect = true;
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                var fileDictionary = new Dictionary<string, string>(); // make this a field (private variable)
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    var filePath = ofd.FileNames[i];
                    var fileName = System.IO.Path.GetFileName(filePath);
                    fileDictionary.Add(fileName, filePath);
                    // not sure about this logic. You may need to reconsider what you are trying to do here.
                    //Instead of doing this, create a click event for the list box and get the selected file path to be played from the dictionary.
                    listbox4.Items.Add(fileName);
                    listbox4.SelectedItem = fileName;
                    mePlayer.Source = new Uri(filePath, UriKind.RelativeOrAbsolute);
                    mePlayer.LoadedBehavior = MediaState.Play;
                }
            }
        }
