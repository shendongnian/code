    private void button2_Click(object sender, EventArgs e)
    {
        // The Remove button was clicked.
        int selectedIndex = listBox1.SelectedIndex;
        try
        {
            // Remove the item in the List.
            words.RemoveAt(selectedIndex); //Remove item from words
            UpdateListBox(words); //Update contents on GUI
            Save(words); //Save on IO
        }
        catch
        {
        }
    }
