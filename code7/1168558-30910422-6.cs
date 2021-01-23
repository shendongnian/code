    #if DEBUG
    
                    //Add object inspector menu item if built in debug mode
                    ToolStripMenuItem inspectorMenuItem = new ToolStripMenuItem();
                    inspectorMenuItem.Text = "Inspect Object";
                    inspectorMenuItem.Image = Properties.Resources.Inspect24x24;
                    inspectorMenuItem.Click += inspectorMenuItem_Click;
                    inspectorMenuItem.Tag = payload;
                    contextMenuStrip.Items.Add(inspectorMenuItem);
    
    #endif
