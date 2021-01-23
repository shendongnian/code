    private void listBoxSnap_MouseUp(object sender, MouseEventArgs e)
    {
        if (listBoxSnap.SelectedIndex == -1 || e.Button != MouseButtons.Right)
            return;
        Rectangle r = listBoxSnap.GetItemRectangle(listBoxSnap.SelectedIndex);
        if (r.Contains(e.Location))
        {
            cm.Show(listBoxSnap, e.Location);
        }
    }
