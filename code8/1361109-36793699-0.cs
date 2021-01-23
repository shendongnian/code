       private void btn_search_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();  
            int valueParsed;
            if(txt_KNr.TextLength == 6)
            {
                if(Int32.TryParse(txt_KNr.Text.Trim(), out valueParsed))
                {
                    Service svc = new Service();
                    WcfServiceGVO.CustomerData data = svc.Connect(txt_KNr.Text);
                    customerDataBindingSource.DataSource = data;
                    //txt_FirstName.DataBindings.Add("Text", data, "FirstName");
                    //txt_LastName.DataBindings.Add("Text", data, "LastName");
                    //txt_Street.DataBindings.Add("Text", data, "Street");
                    //txt_PLZ.DataBindings.Add("Text", data, "PLZ");
                    //txt_Location.DataBindings.Add("Text", data, "Location");
                    //lbl_ampErg.DataBindings.Add("Text", data, "Ampel");                    
                }   
	}
