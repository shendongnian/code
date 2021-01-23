    void btn_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            txtNumPad.Text = txtNumPad.Text + btn.Text;
        }
    }
