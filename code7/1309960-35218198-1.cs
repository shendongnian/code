    // On the EXISTING Form1 instance change the button
    // providing that "button1_Click" method belongs to "Form1" class
    private void button1_Click(object sender, EventArgs e)
    {
        txtOn.Text = "test!";
        System.Diagnostics.Debug.WriteLine("button clicked!");
    }
