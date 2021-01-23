    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
          { checkBox1.ImageIndex = 1; checkBox1.Text = "Sue"; }
        else
          { checkBox1.ImageIndex = 2; checkBox1.Text = "Ellen"; }
    }
