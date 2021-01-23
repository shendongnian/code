            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;
            foreach (string s in sAll.AllKeys)
            {
                var applicationNamevalue = sAll [s];
                button.Text = applicationNamevalue + i; //and set it as button text.
            }
