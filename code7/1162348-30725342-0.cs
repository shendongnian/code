    foreach (Control item in this.form1.Controls)
    {
        System.Web.UI.HtmlControls.HtmlInputText tbx = item as System.Web.UI.HtmlControls.HtmlInputText;
        if (tbx!= null)
        {
            if(tbx.Text == "some text")
                 tbx.Visible = false; // or true how ever you want it
            else
                 tbx.Visible = true;
        }
    }
