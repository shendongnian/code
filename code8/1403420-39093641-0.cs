    protected void Page_Load(object sender, EventArgs e) {
        if (Session["ClusterId"] != null) {
            try {
                int ClusterId = int.Parse(Session["ClusterId"]);
                // Code here
            } catch { }
            Session.Remove("ClusterId");
            return;
        }
    }
    protected void btnSearchBestPrice_Click(object sender, EventArgs e) {
        int ClusterId = int.Parse(Request["ClusterId"]);
        Session.Add("ClusterId", ClusterId.ToString());
        Response.Redirect("~/Default");
    }
