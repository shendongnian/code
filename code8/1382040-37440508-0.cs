    private void Form2_Load(object sender, EventArgs e){ 
        Button button = new Button();
        button.Location = new Point(200, 30);
        button.Text = "Off";
        this.Controls.Add(button);
        // subscribe to the Click event
        button.Click += button_Click;
    }
    // the Click handler
    private void button_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button == null) return;
        if (button.Text != "On")
        {
            button.Text = "On";
            button.BackColor = Color.Green;
        }
        else if (button.Text == "On")
        {
            button.Text = "Off";
            button.BackColor = Color.Red;
        }
    }
