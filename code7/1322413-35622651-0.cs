    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var applicationSteps = GetApplicationSteps(); //Call the function that gives you the data you need
    
            var lastElement = applicationSteps.Last(); //Get the last element
    
            SubmitActionType.Text = lastElement.SubmitActionTypeId;
        }
    }
