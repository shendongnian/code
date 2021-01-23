        protected void AddExchange_Click(object sender, EventArgs e)
        {
            List<string> stringList;
            if (ViewState["stringList"] == null)
                stringList = new List<string>();
            else
                stringList = ViewState["stringList"] as List<string>;
        
            stringList.Add(AddAdditionalTxt.Text);
            foreach (string myStr in stringList)
	        {
                LinkButton link2 = new LinkButton();
                link2.Text = myStr;
                //   link2.Command += new     CommandEventHandler(LinkButton_Command);
                ExchangePanel.Controls.Add(link2);
	        }
            ViewState["stringList"] = stringList;
        }
