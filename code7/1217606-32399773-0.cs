    // Create the checkboxes
    CheckBox cb1 = new CheckBox();
    CheckBox cb2 = new CheckBox();
    CheckBox cb3 = new CheckBox();
    CheckBox cb4 = new CheckBox();
    private void Form1_Load(object sender, EventArgs e)
    {
        // Positioning
        cb1.Left = 10;
        cb2.Left = 10;
        cb3.Left = 10;
        cb4.Left = 10;
        cb1.Top = 10;
        cb2.Top = 30;
        cb3.Top = 50;
        cb4.Top = 70;
        // IMPORTANT BIT - Assign even handlers
        cb1.Click += new EventHandler(CbClick);
        cb2.Click += new EventHandler(CbClick);
        cb3.Click += new EventHandler(CbClick);
        cb4.Click += new EventHandler(CbClick);
        // Add to form
        this.Controls.Add(cb1);
        this.Controls.Add(cb2);
        this.Controls.Add(cb3);
        this.Controls.Add(cb4);
    }
    private void CbClick(object sender, EventArgs e)
    {
        // Uncheck all
        cb1.Checked = false;
        cb2.Checked = false;
        cb3.Checked = false;
        cb4.Checked = false;
        // Check the one that was clicked
        (sender as CheckBox).Checked = true;
    }
