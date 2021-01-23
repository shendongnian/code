    //to get number of panel present in main panel so that new panel position can be set
    int counT = panel1.Controls.Count;
    var pos = this.panel1.AutoScrollPosition; // Whe are storing scroll position
    this.panel1.AutoScrollPosition = new Point(Size.Empty);
    Panel p = new Panel();
    p.Location = new Point(3, 3 + (counT * 197));
    p.Size = new Size(280, 150);
    p.BorderStyle = BorderStyle.FixedSingle;
    
    
    //To add panel to parent panel
    panel1.Controls.Add(p);
    this.panel1.AutoScrollPosition = new Point(pos.X, pos.Y*-1); // We are restoring scroll position
