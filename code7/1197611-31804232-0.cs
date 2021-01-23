    ImageOnDB = dr["ImageOn"].ToString();
    if (ImageOnDB.ToString() != "")
    {
        ImageOn.Visible = true;
        ImageOn.ImageUrl = dr["ImageOn"].ToString();
        ImageOn.NavigateUrl = dr["ImageOn"].ToString();
        ImageOn.ToolTip = dr["ImageOn"].ToString();
        ImageOn.Target = "_blank";
        FileUpload1.Visible = false;
    }
    else
    {
        ImageOn.Visible = false;
        FileUpload1.Visible = true;
    } 
