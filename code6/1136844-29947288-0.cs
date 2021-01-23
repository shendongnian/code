    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo HI = listView1.HitTest(e.Location);
        if (e.Button == MouseButtons.Right)
        {
            if (HI.Location == ListViewHitTestLocations.None)  
            {
                contextMenuFilesListbox.Items[0].Visible = false;
                contextMenuFilesListbox.Items[1].Visible = false;
            }
            else
            {
                contextMenuFilesListbox.Items[0].Visible = true;
                contextMenuFilesListbox.Items[1].Visible = true;
            }
            contextMenuFilesListbox.Show(Cursor.Position);
        }
    }
