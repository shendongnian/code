     protected void gvNoticeBoardDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    if (e.CommandName.ToLower().Equals("deletenotice"))
                    {
                        
                        GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                        NoticeBoard notice = new NoticeBoard();                       
                        HiddenField lblCust = (HiddenField)row.FindControl("hdngvMessageId");//Fetch the CourierId from the selected record
                                            
                        auditTrail.Action = DBAction.Delete;                       
                        Service simplyHRClient = new Service();
                        MessageClass messageClass = simplyHRClient.SaveNoticeBoard(notice, auditTrail);
                        if (messageClass.IsSuccess)
                        {
                            this.Page.AddValidationSummaryItem(messageClass.MessageText, "save");
                            showSummary.Style["display"] = string.Empty;
                            showSummary.Attributes["class"] = "success-message";
                            if (messageClass.RecordId != -1)
                                lblCust.Value = messageClass.RecordId.ToString();
                        }
                        else
                        {
                            this.Page.AddValidationSummaryItem(messageClass.MessageText, "save");
                            showSummary.Style["display"] = string.Empty;
                            showSummary.Attributes["class"] = "fail-message";
                        }
						//Bind Again grid
                        GetAllNoticeBoard();
						}
                 }
