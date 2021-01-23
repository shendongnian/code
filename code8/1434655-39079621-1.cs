         private Dictionary<string, string> fileDictionary = new Dictionary<string, string>(); 
        private void load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".mp3";
            ofd.Filter = "All|*.*";
            ofd.Multiselect = true;
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
               
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    var filePath = ofd.FileNames[i];
                    var fileName = System.IO.Path.GetFileName(filePath);
                    fileDictionary.Add(fileName, filePath);
                    // not sure about this logic. You may need to reconsider what you are trying to do here.
                    //Instead of doing this, create a click event for the list box and get the selected file path to be played from the dictionary.
                    listbox4.Items.Add(fileName);                  
                }
            }
        }
     private void listbox4_SelectionChanged(object sender, SelectionChangedEventArgs e) 
     { 
        if (listbox4.SelectedItem != null) 
        { 
            var selectedFile = listbox4.SelectedItem.ToString();
            string selectedFilePath;
            fileDictionary.TryGetValue(selectedFile, out selectedFilePath);
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                mePlayer.Source = new Uri(selectedFilePath, UriKind.RelativeOrAbsolute);
                mePlayer.LoadedBehavior = MediaState.Play;
            }
        } 
     }
