    if (ddluser.SelectedIndex == 1)
    {
        if (ddlstatus.SelectedItem.Text == "Done")
        {
            query = "select Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
             "u.BatchName='" + ddlbatchname.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and ReviewStatus='" + ddlstatus.SelectedValue + "'";
        }
        else 
        {
            query = "select  Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and (ReviewStatus IS NULL)";
        }
     }
    else
    {
        if (ddlstatus.SelectedItem.Text == "Done")
        {
            query = "select  Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and u.empid='" + ddluser.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and ReviewStatus='" + ddlstatus.SelectedValue + "'";
        }
        else
        {
            query = "select  Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and u.empid='" + ddluser.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and (ReviewStatus IS NULL)";
         }
    }
