    private void button1_Click(object sender, EventArgs e)
    {
        MyUserControl userControl = new MyUserControl();
        panel1.Controls.Add(userControl);
        userControl.Dock = DockStyle.Fill;
    }
