    public void Controls()
      {
    	   var applications = ConfigurationManager.GetSection("ApplicationList") as NameValueCollection;
            for (int i = 0; i < applications.Count; i++)
            {
                var button = new Button();
    
                this.Controls.Add(button);
                top += button.Height+25;
                button.Tag = i;
                button.Text = applications[i].ToString();
            }
       }
 
