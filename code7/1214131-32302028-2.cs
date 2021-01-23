    private void UpButton_Click(object sender, EventArgs e)
    {
        //If there is a selected item in ListView
        if (this.listView1.SelectedIndices.Count >= 0)
        {
            //If selected item is not the first item in list 
            if (this.listView1.SelectedIndices[0] > 0)
            {
                var index = this.listView1.SelectedItems[0].Index;
                var item = this.listView1.SelectedItems[0];
                this.listView1.Items.RemoveAt(index);
                this.listView1.Items.Insert(index - 1, item);
                this.UpdateLayout();
            }
        }
    }
    private void DownButton_Click(object sender, EventArgs e)
    {
        //If there is a selected item in ListView
        if (this.listView1.SelectedIndices.Count >= 0)
        {
            //If selected item is not the last item in list 
            if (this.listView1.SelectedIndices[0] < this.listView1.Items.Count - 1)
            {
                var index = this.listView1.SelectedItems[0].Index;
                var item = this.listView1.SelectedItems[0];
                this.listView1.Items.RemoveAt(index);
                this.listView1.Items.Insert(index + 1, item);
                this.UpdateLayout();
            }
        }
    }
