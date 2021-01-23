    private void listbox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //This plays the MediaElement, but it doesn't have a Source to play yet!
        //media1.Play();
        //Instead, let's set the Source:
        if (listbox4.SelectedItem != null)
        {
            media1.Source = new Uri(listbox4.SelectedItem.ToString(), UriKind.RelativeOrAbsolute);
        }
    }
