    private void tabControl1_MouseDown(object sender, MouseEventArgs e)
    {
        var lastIndex = this.tabControl1.TabCount - 1;
        if (this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))
        {
            this.tabControl1.TabPages.Insert(lastIndex, "New Tab");
            this.tabControl1.SelectedIndex = lastIndex;
        }
        else
        {
            for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                var tabRect = this.tabControl1.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.DeleteButton_Image;
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
