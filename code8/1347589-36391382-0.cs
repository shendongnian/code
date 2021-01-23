    private void timer1_Tick(object sender, EventArgs e)
    {
        label1.Text = label1.Text.Substring(label1.Text.Length - 1) + label1.Text.Remove(label1.Text.Length - 1);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        // The total spaces required to fill the form vary from form.width and the initial label.text.width
        // Width | Spaces
        //  177  |   13
        //  228  |   30
        //  297  |   53
        //  318  |   60
        // The spacesEnd = 60 work for a form with width 319
        int spacesBegin = 0, spacesEnd = 60;
        label1.Text = "Time:" + System.DateTime.Now.ToString();
        label1.AutoSize = false;
        label1.Left = -3;
        label1.Width = this.Width - 1;
        label1.Height = 15;
        label1.BorderStyle = BorderStyle.FixedSingle;
        for (int i = 0; i < spacesBegin; i++)
            label1.Text = " " + label1.Text;
        for (int i = 0; i < spacesEnd; i++)
            label1.Text += " ";
        Timer timer = new Timer();
        timer.Tick += timer1_Tick;
        timer.Interval = 50;
        timer.Start();
    }
