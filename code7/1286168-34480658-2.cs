    private void DropList_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent("myFormat") ||
            sender == e.Source)
        {
            e.Effects = DragDropEffects.None;
        }
    }
        
        private void DropList_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent("myFormat"))
        {
            Contact contact = e.Data.GetData("myFormat") as Contact;
            ListView listView = sender as ListView;
            listView.Items.Add(contact);
        }
    }
