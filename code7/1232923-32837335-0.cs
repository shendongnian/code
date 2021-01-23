    foreach (GridViewRow row in GridViewReview.Rows)
    {
        Control reviewBtn = row.FindControl("ButtonReview") as Button;
    
        if (reviewBtn.Visible == true)
        {
             btn_reviewAll.Visible = true;
             break;
        }
        else
        {
           btn_reviewAll.Visible = false;
        }
    }
