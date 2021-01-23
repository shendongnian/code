    listView1.View = View.Tile;
    listView1.OwnerDraw = true;
    listView1.DrawItem += listView1_DrawItem;
    listView1.TileSize = new Size(48,
      listView1.ClientSize.Height - (SystemInformation.HorizontalScrollBarHeight + 4));
    for (int i = 0; i < 25; ++i) {
      listView1.Items.Add(new ListViewItem(i.ToString()));
    }
    void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
      Color textColor = Color.Black;
      if ((e.State & ListViewItemStates.Selected) != 0) {
        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        textColor = SystemColors.HighlightText;
      } else {
        e.Graphics.FillRectangle(Brushes.White, e.Bounds);
      }
      e.Graphics.DrawRectangle(Pens.DarkGray, e.Bounds);
      TextRenderer.DrawText(e.Graphics, e.Item.Text, listView1.Font, e.Bounds,
                            textColor, Color.Empty,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
