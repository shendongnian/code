    if (cb_Shuffle.IsChecked == true)
    {
        newIndex = r.Next(dgPlayList.Items.Count);
    }
    else
    {
        if (newIndex >= (dgPlayList.Items.Count - 1))
        {
            // If the end of the datagrid is reached, set index to 0 for playing the first track
            newIndex = 0;
        }
        else
        {
            // Is there a following track in the datagrid, then use the next calculated index
            newIndex += 1;
        }
    }
