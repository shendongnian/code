    public class Default : System.Web.UI.Page 
    {           
       protected void Page_Load(object sender, System.EventArgs e) 
       {     
       }
       -- OR --
       protected override void OnLoad(EventArgs e) 
       {
          base.OnLoad(e);
       }
    }
