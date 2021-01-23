    public void Save_Click(object sender, eventargs args)
    {
        foreach(var item in List.Where(vm=>vm.IsSelected))
        {
            item.Save();
        }
        MessageBox.Show("Saved");
    }
