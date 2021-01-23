        TextBox tb = new TextBox();
                tb.ID = "PQ1" ;
                // need to add the name, so later to get the post back using that.
                tb.Attributes["name"] = "PQ1";
                tb.Attributes.Add("placeholder", "Professional Qualifications 1" );
                tb.Attributes["class"] = "form-control";                        
                tb.Height = 100;
        if (IsPostBack)
            txtDebug.Text = "Value is: " + Request.Form["PQ1"];
