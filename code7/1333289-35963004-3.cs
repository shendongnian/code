    private void Button_Click(object sender, RoutedEventArgs e)
    {
        for(var i = 0; i < result.Items.Count; i++)
        {
            // itemsToRemove should be populated with the IDs you want to remove.
            if(itemsToRemove.Contains(result.Items[i])
            {
                result.RemoveAt(i);
            }
        }
        result.Items.Add(ID);
    }
