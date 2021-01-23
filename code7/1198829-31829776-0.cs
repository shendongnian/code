    foreach (var control in form1.Controls)
        {
            if (control is WebControl)
            {
                (control as WebControl).Enabled = false;
            }
            else if (control is ListControl)
            {
                (control as ListControl).Enabled = false;
            }
            else if (control is HtmlInputControl)
            {
                (control as HtmlInputControl).Disabled = true;
            }
        }
