    protected void rpt_Answers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RadioButtonList rblAnswers = (RadioButtonList)e.Item.FindControl("rbtAnswers");
    
    
            System.Data.DataRowView drAnswer;
            drAnswer = (DataRowView)e.Item.DataItem;
            rblAnswers.DataSource = drAnswer["Answer"];
            rblAnswers.DataBind();
        }
    }
