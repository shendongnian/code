    protected void btnAdd_Click(object sender, EventArgs e)
    {
        for (var i = 0; i < lstMain.Items.Count; i++)
        {
            var list = lstMain.Items[i];
            if(!list.Selected) continue;
            lstFAvourite.ClearSelection();
            lstFAvourite.Items.Add(list);
            lstMain.Items.Remove(list);
            //Decrement counter since we just removed an item            
            i--;
        }
    }
