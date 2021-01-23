    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int index = comboBox.SelectedIndex;
        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = store.CreateFile("selectedIndex"))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(index.ToString());
                }
            }
        }
    }
    private void OnComboBoxLoaded(object sender, RoutedEventArgs e)
    {
        int index = GetPreviousIndex();
        comboBox.SelectedIndex = index;
        comboBox.Text = comboBox.Items[index] as string;
    }
    private int GetPreviousIndex()
    {
        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = store.OpenFile("selectedIndex", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    try
                    {
                        return int.Parse(reader.ReadString());
                    }
                    catch (Exception x)
                    {
                        return -1;
                    }
                }
            }
        }
    }
