    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : Page
    {
        public string btnNoTooltip = "No IDs are calculated";
        public string btnTooltip = "The calculated IDs are:";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    
        public void LinkButton_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("LinkButtonOrder"))
            {
                LinkButton lkTrigger = (LinkButton)sender;
                if (lkTrigger.ToolTip.Equals(btnNoTooltip))
                {
                    lkTrigger.ToolTip = btnTooltip + " " + e.CommandArgument;
                }
                else
                {
                    lkTrigger.ToolTip += " " + e.CommandArgument;
                }
                
                Random random = new Random();
                lkTrigger.CommandArgument = random.Next(0, 100).ToString();
                
                Label1.Text = "Triggered: " + e.CommandName + " with Argument " + e.CommandArgument;
            }
        }
    }
