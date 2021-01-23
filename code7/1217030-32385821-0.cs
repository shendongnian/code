    protected void surveyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
                RadioButtonList surveyList = (RadioButtonList)sender;
                string value = surveyList.SelectedValue;
                RepeaterItem row = (RepeaterItem)surveyList.NamingContainer;
                if (value == "1" || value == "2")
                {
                    ((RequiredFieldValidator)row.FindControl("RFV2")).Enabled = true;
                }
                else
                {
                    ((RequiredFieldValidator)row.FindControl("RFV2")).Enabled = false;
                }
        }
