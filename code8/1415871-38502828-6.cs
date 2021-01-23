    private void button3_Click(object sender, EventArgs e)
    {
        // Instantiate the form
        var form = new Form2(label1.Text);
        // Assign a lambda method to the FormClosed event to re-enable button3
        form.FormClosed += (s, a) => button3.Enabled = true;
        // Disable button3
        button3.Enabled = false;
        // Show the form
        form.Show();
    }
