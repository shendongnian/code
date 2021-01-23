    private void btnRemove_Click(object sender, EventArgs e)
    {
        if(c.SelectedIndex == -1)
            return;
            
        BindingSource bs = c.DataSource as BindingSource;
        bs.RemoveAt(c.SelectedIndex);
        
        // Just to show the updated list 
        foreach(string u in users)
            Console.WriteLine(u);
    }
