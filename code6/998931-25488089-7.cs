    // UI Thread safe helper for adding an item
    private void Add(string name, ulong size)
    {
    	if (this.listView1.InvokeRequired)
    	{
    		this.listView1.Invoke(new MethodInvoker(() => Add(name, size)));
    	}
    	else
    	{
    		var lvi = new ListViewItem(name);
    		lvi.SubItems.Add(size.ToString());
    
    		this.listView1.Items.Add(lvi);
    	}
    }
