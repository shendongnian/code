    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var tabPage = this.tabControl1.TabPages[e.Index];
        var tabRect = this.tabControl1.GetTabRect(e.Index);
        tabRect.Inflate(-2, -2);
        if (e.Index == this.tabControl1.TabCount - 1)
        {
            var addImage = Properties.Resources.AddButton_Image;
            e.Graphics.DrawImage(addImage,
                tabRect.Left + (tabRect.Width - addImage.Width) / 2,
                tabRect.Top + (tabRect.Height - addImage.Height) / 2);
        }
        else
        {
            var closeImage = Properties.Resources.DeleteButton_Image;
            e.Graphics.DrawImage(closeImage,
                (tabRect.Right - closeImage.Width),
                tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.Left);
        }
    }
