    protected void clearAnswers()
    {
    
        CheckBoxList cblAnswers = this.FindControl("cblAnswers");
        RadioButtonList rblAnswers = this.FindControl("rblAnswers");
        
    
        if (cblAnswers != null)
        {
            Page.Form.Controls.Remove(cblAnswers);
        }
    
        if (rblAnswers != null)
        {
            Page.Form.Controls.Remove(rblAnswers);
        }
    }
