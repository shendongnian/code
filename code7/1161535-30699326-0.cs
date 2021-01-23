    protected void  Sale_CheckedChanged(object sender, EventArgs e)
    {
        if (Sale.Checked)
        {
            UpdatePanel1.Visible = true;
            PriceLabel.Text = " Sale Price:";
            Application.DoEvents();
        }
    }
        protected void  Rent_CheckedChanged(object sender, EventArgs e)
    {
            if (Rent.Checked)
        {
            UpdatePanel1.Visible=true;
            PriceLabel.Text = " Rent Price:";
            Application.DoEvents();
        }
    }
