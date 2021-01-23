    Image CloseImage;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
        tabControl2.DrawItem += TabControl2_DrawItem;
        tabControl2.MouseClick += tabControl2_MouseClick;
        CloseImage = Properties.Resources.Close;
    }
    
    
    private void TabControl2_DrawItem(object sender, 
                                      System.Windows.Forms.DrawItemEventArgs e)
    {
        try
        {
            var tabRect = this.tabControl2.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                     tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                     CloseImage.Width,
                                     CloseImage.Height);
    
            var sf = new StringFormat(StringFormat.GenericDefault);
            if (this.tabControl2.RightToLeft == System.Windows.Forms.RightToLeft.Yes &&
                this.tabControl2.RightToLeftLayout == true)
            {
                tabRect = GetRTLCoordinates(this.tabControl2.ClientRectangle, tabRect);
                imageRect = GetRTLCoordinates(this.tabControl2.ClientRectangle, imageRect);
                sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
    
            e.Graphics.DrawString(this.tabControl2.TabPages[e.Index].Text,
                                  this.Font, Brushes.Black, tabRect, sf);
            e.Graphics.DrawImage(CloseImage, imageRect.Location);
    
        }
        catch (Exception) { }
    }
    
    private void tabControl2_MouseClick(object sender, MouseEventArgs e)
    {
    
        for (var i = 0; i < this.tabControl2.TabPages.Count; i++)
        {
            var tabRect = this.tabControl2.GetTabRect(i);
            tabRect.Inflate(-2, -2);
            var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                     tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                     CloseImage.Width,
                                     CloseImage.Height);
            if (imageRect.Contains(e.Location))
            {
                this.tabControl2.TabPages.RemoveAt(i);
                break;
            }
        }
    }
    
    public static Rectangle GetRTLCoordinates(Rectangle container, Rectangle drawRectangle)
    {
        return new Rectangle(
            container.Width - drawRectangle.Width - drawRectangle.X,
            drawRectangle.Y,
            drawRectangle.Width,
            drawRectangle.Height);
    }
