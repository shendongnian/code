    protected void RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Total = 2;
            if (RadioButtonList.Items[0].Selected)
            {
                Total++;
            }
            if (RadioButtonList.Items[1].Selected)
            {
                Total = 0;
            }
            Label1.Text = Convert.ToString(Total);
        }
