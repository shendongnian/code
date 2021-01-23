    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            lblResult.Text = "You Got It!";
            lblResult.ForeColor = Color.Green;
        }
        else
        {
            lblResult.Text = "Incorrect";
            lblResult.ForeColor = Color.Red;
        }
    }
