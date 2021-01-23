        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("window.open('OverwriteConfiguration.aspx', 'PopUp',");
        sb.Append("'top=0, left=0, width=500, height=500, menubar=no,toolbar=no,status,resizable=yes,addressbar=no');<");
     
        LinkButton l = (LinkButton)e.Row.FindControl("lnkView");
        l.Attributes.Add("onclick", sb.ToString());
