    private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var Test = treeView1.HitTest(e.Location);
        if (Test.Location == TreeViewHitTestLocations.PlusMinus)
        { 
           //You can check here
        }
    }
