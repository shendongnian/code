    protected void Page_Load(object sender, EventArgs e)
        {
            statusChk.Checked = status("de_cancel");
        }
        protected bool status(string strStatus)
        {
            if (strStatus == "de_cancel")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
