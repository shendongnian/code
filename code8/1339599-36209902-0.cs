    public partial class _default : System.Web.UI.Page
        {
            static int i = 0;
    
            protected override void OnInit(EventArgs e)
            {
    	    base.OnInit(e);
                LinkButton lb = new LinkButton();
                lb.ID = "id";
                lb.Text = "Click me";
                lb.CommandArgument = "argument";
                lb.Command += new CommandEventHandler(method_to_call);
                this.Panel.Controls.Add(lb);
            }
    
            private void method_to_call(object sender, CommandEventArgs e)
            {
                i++;
                this.Label.Text = i.ToString();
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            
        }
  
