    private void radioButtons_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = sender as RadioButton;
        if (rb.Checked)
        {
            Console.WriteLine(rb.Text);
        }
    }
