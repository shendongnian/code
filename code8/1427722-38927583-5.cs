    protected void Button1_Click(object sender, EventArgs e)
    {
        UpdateLabels();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        UpdateLabels();
    }
    private void UpdateLabels()
    {
        Label1.Text = DateTime.Now.ToString();
        Label2.Text = DateTime.Now.ToString();
    }
