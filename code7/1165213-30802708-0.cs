    // in your Masterpage
    public void UpdateComment(string comment)
    {
       this.LblComment.Text = comment;    // as label in the green part of the master
       this.CommentUpdatePanel.Update();  // the UpdatePanel around this control
    }
