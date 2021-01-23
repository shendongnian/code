    protected void btnToggle_Click(object sender, EventArgs e)
        {
            string s = btnToggle.Text;
            switch (s)
            {
                case "Hide":
                    btnToggle.Text = "Show";
                    break;
                case "Show":
                    btnToggle.Text = "Hide";
                    break;
            }
            ucDetails myControl = (ucDetails)Page.LoadControl("~/ucDetails.ascx");
            UserControlHolder.Controls.Add(myControl);
            myControl.Visible = !myControl.Visible;
        }
