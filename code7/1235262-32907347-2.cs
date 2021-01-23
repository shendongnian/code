    private void button1_Click(object sender, EventArgs e)
    {
        this.checkedListBox1.CheckedItems.Cast<ItemModel>()
            .ToList()
            .ForEach(item =>
            {
                MessageBox.Show(string.Format("Id:{0}, Name:{1}", item.Id, item.Name));
            });
    }
