    void editList(string message, string fileName, int number, int image)
    {
        ListViewItem dummyrow = new ListViewItem(new string[] {"loading", ""});
        listView1.BeginUpdate();
        try
        {
            string[] row = { message, fileName };
            var listViewItem = new ListViewItem(row);
            listViewItem.ImageIndex = image;
            while (listView1.Items.length <= number) {
              //if the listview doesn't have enough rows yet,
              //add a loading message as placeholder
              listView1.Items.add(dummyrow);
            }
            listView1.Items[number] = (listViewItem);
        }
        catch (Exception ex)
        {
            MessageBox.Show(number + " | " + ex.Message + Environment.NewLine + fileName + Environment.NewLine + message + Environment.NewLine + "COUNT: "+listView1.Items.Count);
        }
    
        listView1.EndUpdate();
    }
