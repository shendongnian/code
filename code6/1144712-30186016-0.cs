    protected override void InitializeCulture()
        {
            string value  = Request.Form["dropdownlist1"];       
            if (!string.IsNullOrEmpty(value))
            {
                this.Culture = value;
                this.UICulture = value;
            }    
            base.InitializeCulture();
        }
