    panel.ControlAdded += panel_ControlAdded;
    void panel_ControlAdded(object sender, ControlEventArgs e) {
      panel.AutoScrollMinSize = new Size(0,
        panel.Controls.Cast<Control>().Sum(x => x.Height));
    }
