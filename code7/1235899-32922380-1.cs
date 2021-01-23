    void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.DoDragDrop(listView1.SelectedItems[0].ImageIndex + "", 
                          DragDropEffects.Move);
            }
        }
    }
