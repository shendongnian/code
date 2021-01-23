    protected void clearAnswers()
    {
    
        CheckBoxList cblAnswers = (CheckBoxList)this.FindControl("cblAnswers");
        RadioButtonList rblAnswers = (RadioButtonList)this.FindControl("rblAnswers");
        
    
        if (cblAnswers != null)
        {
            Page.Form.Controls.Remove(cblAnswers);
        }
    
        if (rblAnswers != null)
        {
            Page.Form.Controls.Remove(rblAnswers);
        }
    }
