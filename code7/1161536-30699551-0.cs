        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == 1)
        {
            UpdatePanel1.Visible = true;
            PriceLabel.Text = "Text1:";
        }
        else
        {
            UpdatePanel2.Visible = true;
            PriceLabel.Text = "Text2:";
        }
    }
