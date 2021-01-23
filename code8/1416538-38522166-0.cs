    void bclick(object sender, DataListCommandEventArgs e)
        {
            foreach (DataListItem item in DataList1.Items)
            {
                HtmlInputRadioButton radio = (item.FindControl("radioButton") as HtmlInputRadioButton);
                if (radio.Checked)
                {
                    // this is you checked radio
                }
            }
        }
