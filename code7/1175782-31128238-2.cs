        protected override void Render(HtmlTextWriter writer)
        {
            if(Request.HttpMethod == "POST")
            {
                MyDevicesTable.Render(writer);
                return;
            }
    
            base.Render(writer);
        }
