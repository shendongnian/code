    this.GroupFiles.Location = new Point(6, 6);
    this.GroupFiles.Size = this.Size - new Size(12, 12); // set initial size
    this.GroupFiles.AutoSize = false; // and autosize to false
    this.GroupFiles.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
    // ...
    
    // same thing for the grid view
    this.DGV_LogFiles.Location = new Point(9, 18);
    this.DGV_LogFiles.Size = this.GroupFiles.Size - new Size(18, 36);
    this.DGV_LogFiles.AutoSize = false;
  
