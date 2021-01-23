    private void btnNum_Click(object sender, EventArgs e)
    {
        var button = sender as Button
        txtOutput.Text += button.Content.ToString();
    }
