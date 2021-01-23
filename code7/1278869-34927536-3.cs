        protected void ZoomIn_Click(object sender, EventArgs e)
    {
        var c = Request.Cookies["TiffViewer"];
        string key = c["Key"];
        if (Cache[key] != null)
        {
            float chg = -10.0f;
            float percent = 0.0f;
            float.TryParse(Request.QueryString["ChangeSize"], out percent);
            percent += chg;
            int ImHeight = 0;
            int.TryParse(c["ImHeight"], out ImHeight);
            int ImWidth = 0;
            int.TryParse(c["ImWidth"], out ImWidth);
            string myHeight = "0";
            string myWidth = "0";
            if (ImHeight > 0 && ImWidth > 0)
            {
                ImHeight = (int)(ImHeight * (1 + (percent / 100)));
                myHeight = ImHeight.ToString();
                ImWidth = (int)(ImWidth * (1 + (percent / 100)));
                myWidth = ImWidth.ToString();
            }
            Response.Cookies["TiffViewer"]["ReturnURL"] = c["ReturnURL"];
            Response.Cookies["TiffViewer"]["Key"] = c["Key"];
            Response.Cookies["TiffViewer"]["ImHeight"] = myHeight;
            Response.Cookies["TiffViewer"]["ImWidth"] = myWidth;
            Response.Cookies["TiffViewer"]["PageCount"] = c["PageCount"];
            Response.Redirect("~/Viewer/Viewer.aspx?ChangeSize=" + percent.ToString());
        }
    }
    
    protected void ZoomOut_Click(object sender, EventArgs e)
    {
        var c = Request.Cookies["TiffViewer"];
        string key = c["Key"];
        if (Cache[key] != null)
        {
            float chg = 10.0f;
            float percent = 0.0f;
            float.TryParse(Request.QueryString["ChangeSize"], out percent);
            percent += chg;
            int ImHeight = 0;
            int.TryParse(c["ImHeight"], out ImHeight);
            int ImWidth = 0;
            int.TryParse(c["ImWidth"], out ImWidth);
            string myHeight = "0";
            string myWidth = "0";
            if (ImHeight > 0 && ImWidth > 0)
            {
                ImHeight = (int)(ImHeight * (1 + (percent / 100)));
                myHeight = ImHeight.ToString();
                ImWidth = (int)(ImWidth * (1 + (percent / 100)));
                myWidth = ImWidth.ToString();
            }
            Response.Cookies["TiffViewer"]["ReturnURL"] = c["ReturnURL"];
            Response.Cookies["TiffViewer"]["Key"] = c["Key"];
            Response.Cookies["TiffViewer"]["ImHeight"] = myHeight;
            Response.Cookies["TiffViewer"]["ImWidth"] = myWidth;
            Response.Cookies["TiffViewer"]["PageCount"] = c["PageCount"];
            Response.Redirect("~/Viewer/Viewer.aspx?ChangeSize=" + percent.ToString());
        }
    }
