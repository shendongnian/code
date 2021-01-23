    private void Form1_Load(object sender, EventArgs e)
    {
        AnotherNamespace.Form2 F2 = new AnotherNamespace.Form2();
        F2.Show();
        F2.button1.Click += button2_Click;
    }
