    void Listbox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {     
            int index = Listbox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
              object clickedItem = Listbox1.Items[index];
              // open your form here
            }                
    }
