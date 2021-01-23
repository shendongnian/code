    // Put your controls here so they're accessible
    UC1 uc1;
    UC2 uc2;
    UC3 uc3;
    private void Form1_Load(object sender, EventArgs e)
    {
        // Do this on form load so it only happens once
        // Instantiate your controls
        uc1 = new UC1();
        uc2 = new UC2();
        uc3 = new UC3();
        // Make them invisible
        uc1.Visible = false;
        uc2.Visible = false;
        uc3.Visible = false;
        // Add your controls
        Controls.Add(uc1);
        Controls.Add(uc2);
        Controls.Add(uc3);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        // You can keep using bring to front
        uc1.BringToFront();
        // OR
        // Use show/hide
        uc1.Show();
        uc2.Hide();
        uc3.Hide();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        uc2.BringToFront();
        // OR show hide...
    }
    private void button3_Click(object sender, EventArgs e)
    {
        uc3.BringToFront();
    }
