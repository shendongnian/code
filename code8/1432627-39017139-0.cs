        protected void Page_Load(object sender, EventArgs e)
        {
            for (int ctr = 0; ctr <= 2; ctr++)
            {
                LinkButton link = new LinkButton();
                link.ID = "lnk" + ctr.ToString();
                link.Text = "lnkName" + ctr.ToString();
                link.Click += delegate { Label1.Text = link.ID; };
                this.form1.Controls.Add(link);
            }
        }
