    void onCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index != -1)
        {
            string file = listView1.Items[e.Index].Text;
            if (filesSelected.Contains(file))
                filesSelected.Remove(file);
            else
                filesSelected.Add(file);
        }
    }
