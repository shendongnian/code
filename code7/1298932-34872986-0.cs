    private const string OPERATORS = "+-/*";
    protected void btnPlus_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBox1.Text) || // check if string is empty
            OPERATORS.Contains(txtBox1.Text.Last())) // or if last character is a operator
        {
            txtBox1.Text = txtBox1.Text;
        }
        else
        {
            txtBox1.Text = txtBox1.Text + "+";
            ViewState["Operation"] = "+";
        }
    }
