    ToolStripMenuItem NLMenu = new ToolStripMenuItem("NL");
    //store the filename here for later
    NLMenu.Tag = Path.Combine(dir.FullName, "nl.txt");
    //attach the click handler
    NLMenu.Click += toolStripMenuItem_Click;
    //repeat for PLMenu...
