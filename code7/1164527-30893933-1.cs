    protected void lL_ItemEditing(object sender, ListViewEditEventArgs e)
    {             
    var questionPannel = lL.Items[e.ItemIndex].FindControl("lead_table") as HtmlTable;
    var campaignQuestionsTableRow = questionPannel.FindControl("campaign_questions") as HtmlTableRow;
    // bind fixed controls
    var lead = GetLead();
    var nameControl = ((TextBox)lL.Items[e.ItemIndex].FindControl("Name"))
    nameControl.Text = lead.Name;
    // bind dynamic controls
    var questions = GetQuestions();
         var rep= (Repeater)lL.Items[e.ItemIndex].FindControl("repeatur1");
    rep.DataSource=questions;
     rep.DataBind();
    }
    protected void lL_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        // Get fixed fields
       // var lead = GetLead();
        lead.Name = ((TextBox)lL.Items[e.ItemIndex].FindControl("Name")).Text.Trim();
     Repeater rep=(Repeater)e.FindControl("repeatur1"));
       foreach (RepeaterItem item in rep.Items)
    {
    TextBox t=item.FindControl("txtName") as TextBox;
    //do your work here
       }
    // Switch out of edit mode
    lL.EditIndex = -1;
    }
