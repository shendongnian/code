    // This will set each label's BackColor to Red.
    private void label_Click(object sender, EventArgs e)
    {
        foreach (Label label in labelArray)
        {
            label.BackColor = Color.Red;
        }
    }
    // This will set just the clicked on Label's BackColor to Red.
    private void label_Click(object sender, EventArgs e)
    {
        Label label = sender as Label;
        if (label != null)
        {
            label.BackColor = Color.Red;
        }
    }
