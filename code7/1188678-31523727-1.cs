    private void UpdateChat(string message)
    {
    	if(this.InvokeRequired)
    	{
    		this.Invoke(new MethodInvoker(delegate {
    			lstChat.Items.Insert(lstChat.Items.Count, message);
    			lstChat.SelectedIndex = lstChat.Items.Count - 1;
    			lstCat.Refresh();
    		}));           
    	} else {
    			lstChat.Items.Insert(lstChat.Items.Count, message);
    			lstChat.SelectedIndex = lstChat.Items.Count - 1;
    			lstCat.Refresh();
    	}
    }
