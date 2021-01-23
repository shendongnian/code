        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TblComment item = (TblComment)(e.Item.DataItem);
            Int32 code = Convert.ToInt32(item.CommentCode);
            var replay = (from a in db.TblComments
                          where a.CommentReplayTo == code && a.CommentIsReplay == true && a.CommentIsApprove == true
                          select a).ToList();
            Repeater rptReplay = (Repeater)e.Item.FindControl("rptReplay");
            rptReplay.DataSource = replay;
            rptReplay.DataBind();
           }
    }
