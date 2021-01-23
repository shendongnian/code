    namespace EventWorks.View
    {
        public partial class Event : System.Web.UI.Page, ISecurityRules
        {
            EventController _eventController = new EventController();
    
            protected void btnNew_Click(object sender, EventArgs e)
            {
                _eventController.DoSomething();
            }
    
            protected void btnSave_Click(object sender, EventArgs e)
            {
                _eventController.DoSomething();
            }
        }
    }
