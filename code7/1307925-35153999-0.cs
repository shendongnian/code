    public partial class WebForm1 : System.Web.UI.Page 
    { 
      TextBox txtBox = null; 
    
      protected void Page_Init(object sender, EventArgs e) 
      { 
        txtBox = new TextBox(); 
        txtBox.ID = "newButton"; 
        form1.Controls.Add(txtBox); 
      } 
    
      protected void Page_Load(object sender, EventArgs e) 
      {	
         if (!IsPostBack) 
         { 
           txtBox.Text = "initialVal"; 
         } 
    
         if (IsPostBack && Session["change"] == null) 
         { 
           txtBox.Text = "change"; 
           Session["change"] = true; 
          } 
       } 
    }
