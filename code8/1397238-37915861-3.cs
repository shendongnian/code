    if (ddluser.SelectedIndex == 1)
    {
        if (ddlstatus.SelectedItem.Text == "Done")
        {
            query = "select Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
             "u.BatchName='" + ddlbatchname.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and ReviewStatus='" + ddlstatus.SelectedValue + "'";
        }
        else if (ddlstatus.SelectedItem.Text == "Not Done")
        {
            query = "select  Mts.LineCount,Mts.AudioID,ISNULL(Mts.ReviewStatus,'Not Done') AS ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and (ReviewStatus IS NULL)";
        }
    else 
        {
            query = "select  Mts.LineCount,Mts.AudioID,ISNULL(Mts.ReviewStatus,'Not Done') AS ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID";
        }
     }
    else
    {
        if (ddlstatus.SelectedItem.Text == "Done")
        {
            query = "select  Mts.LineCount,Mts.AudioID,Mts.ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and u.empid='" + ddluser.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and ReviewStatus='" + ddlstatus.SelectedValue + "'";
        }
        else if (ddlstatus.SelectedItem.Text == "Not Done")
        {
            query = "select  Mts.LineCount,Mts.AudioID,ISNULL(Mts.ReviewStatus,'Not Done') AS ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and u.empid='" + ddluser.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID and (ReviewStatus IS NULL)";
         }
     else
        {
            query = "select  Mts.LineCount,Mts.AudioID,ISNULL(Mts.ReviewStatus,'Not Done') AS ReviewStatus,convert(varchar(10), mts.CreatedDate,101) as CreatedDate,u.UserID,si.AuditoName from MTWorkStatus Mts,users u,subjectItems si where " +
            "u.BatchName='" + ddlbatchname.SelectedValue + "' and u.empid='" + ddluser.SelectedValue + "' and mts.TraineeID=u.Empid and si.ID= Mts.AudioID";
         }
    }
 
    SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("HyperLink", typeof(string));
            if (ddlstatus.SelectedItem.Text == "Not Done")
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["HyperLink"] = "NOT DONE";
                }
            }
            else
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string ReviewStatus = dt.Rows[i]["ReviewStatus"].ToString();
                    if (ReviewStatus == "True")
                    {
                        dt.Rows[i]["HyperLink"] = "DONE";
                    }
                }
            }
            dt.AcceptChanges();
            grdbatch.DataSource = dt;
            grdbatch.DataBind();
