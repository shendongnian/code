     public partial class RaisingEventFromUserControl_Question : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                TabControl.ControlUpdated += TabControl_ControlUpdated;
            }
    
            void TabControl_ControlUpdated(object sender, ControlChangedEventArgs e)
            {
                message.Text = String.Format("A child control with an ID of '{0}' was updated. It now has the value of '{1}'.", e.ControlID, e.ControlValue);
            }
        }
