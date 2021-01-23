    bool selecting = false;
    private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        selecting = true;
    }
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        selecting = false;
        // maybe you want to call the Tick now: 
        // timer1_Tick(null, null);
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (selecting) return;
        // do your stuff
        ..
    }
