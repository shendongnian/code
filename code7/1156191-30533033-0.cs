    myListBox.DrawItem += new DrawItemEventHandler(this.DrawItemHandler);
    myListBox.DrawMode = DrawMode.OwnerDrawnFixed;
    private void DrawItemHandler(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        e.DrawFocusRectangle();
        
        OrderItem item = myListBox.Items[e.Index] as OrderItem;
        if (item == null) return;
        Rectangle nameRect = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width / 3, e.Bounds.Height));
        e.Graphics.DrawString(item.ProductName, Font, Brushes.Black, nameRect);
        Rectangle quantityRect = new Rectangle(...);
        e.Graphics.DrawString(item.Quantity.ToString(), Font, Brushes.Black, quantityRect);
    }
