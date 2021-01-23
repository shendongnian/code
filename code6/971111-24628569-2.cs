    private void Form1_Load(object sender, EventArgs e)
    {
        // or whatever you do to create the 2nd form..
        AnotherNamespace.Form2 F2 = new AnotherNamespace.Form2();
        F2.Show();
        // register the click:
        F2.button1.Click += button2_Click;
    }
