    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //index = flipView.SelectedIndex + 1 because when remove one item, next item will be shown, 
        //it will behavior like a new item replace the old one.
        flipviewCollection.Insert(flipView.SelectedIndex + 1, new ImageSourceClass { ImageSource = "Assets/new.jpg" });
        flipviewCollection.Remove(flipView.SelectedItem as ImageSourceClass);                                
    }
