    this.listBox1.SelectedItems.Cast<DataRowView>()
        .ToList()
        .ForEach(item =>
        {
            //item.Delete(); 
            //or
            this.AllPairs.Tables[0].Rows.Remove(item.Row);
        });
