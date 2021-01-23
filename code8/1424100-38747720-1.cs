      protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(ddlOptions.SelectedValue.Trim()); loopcnt++)
        {
            TextBox tb = new TextBox();
            tb.ID = "tb" + loopcnt;
            ctrlPlaceholder.Controls.Add(tb);
        }
    }
     
