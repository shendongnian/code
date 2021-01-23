    this.tabControl1.Padding = new Point(12, 4);
    this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
    this.tabControl1.DrawItem += tabControl1_DrawItem;
    this.tabControl1.MouseDown += tabControl1_MouseDown;
    this.tabControl1.Selecting += tabControl1_Selecting;
    this.tabControl1.HandleCreated += tabControl1_HandleCreated;
