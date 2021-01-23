        protected void btnAccept_OnClick(object sender, EventArgs e)
        {
            List<String> chkList = new List<String>();
            //  All checked checkboxes are sent via the postback. Save this parameters in a list:
            foreach (string s in Request.Params.Keys)
            {
                if (s.ToString().IndexOf("chkBox_") == 0)
                {
                    chkList.Add(s.ToString());
                }
            }
