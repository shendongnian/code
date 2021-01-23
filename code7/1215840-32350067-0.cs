    private void Form1_Load(object sender, EventArgs e)
    {
        // Create radio buttons
        RadioButton rb1 = new RadioButton();
        RadioButton rb2 = new RadioButton();
        RadioButton rb3 = new RadioButton();
        // Positioning on form
        rb1.Left = 10;
        rb2.Left = 10;
        rb3.Left = 10;
        rb1.Top = 10;
        rb2.Top = 30;
        rb3.Top = 50;
        // Assign event handler
        rb1.CheckedChanged += new EventHandler(RadioCheckChanged);
        rb2.CheckedChanged += new EventHandler(RadioCheckChanged);
        rb3.CheckedChanged += new EventHandler(RadioCheckChanged);
        // Add to form
        this.Controls.Add(rb1);
        this.Controls.Add(rb2);
        this.Controls.Add(rb3);
    }
    private void RadioCheckChanged(object sender, EventArgs e)
    {
        // Enable button here
    }
