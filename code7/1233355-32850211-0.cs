    protected void ValidateSubject_Click(object sender, EventArgs e) {
        if ( sender.GetType().FullName == "System.Web.UI.WebControls.CheckBox" ) {
            // Have what you currently have for checkboxes here
        } else if ( sender.GetType().FullName == "System.Web.UI.HtmlControls.HtmlButton" ) {
            // Do something else for the button, probably involving getting the GridView's rows and iterating through them
        }
    }
