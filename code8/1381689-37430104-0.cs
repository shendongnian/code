    public void Controls()
    {
            for (int i = 1; i <= Applications; i++)
            {
                NameValueCollection sAll;
                sAll = ConfigurationManager.AppSettings;
    
                Button button = new Button();
    
                this.Controls.Add(button);
                top += button.Height+25;
                button.Tag = i;
                button.Text = sAll[i] ;
            }
    }
    
