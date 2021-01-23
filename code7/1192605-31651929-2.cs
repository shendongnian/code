    private void showImageonReport(DataTable dt)
        {
            
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                if (dt.Rows[index]["Image"].ToString() != "")
                {
                    string s = this.Server.MapPath(
                                dt.Rows[index]["Image"].ToString());
    
                    if (File.Exists(s))
                    {
                        LoadImage(dt.Rows[index], "image_stream", s);
                    }
                    else
                    {
                        LoadImage(dt.Rows[index], "image_stream",
                                  "DefaultPicturePath");
                    }
                }
                else
                {
                    LoadImage(dt.Rows[index], "image_stream",
                              "DefaultPicturePath");
                }
            }
            
        }
