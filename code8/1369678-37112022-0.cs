    public partial class WebForm1 : System.Web.UI.Page
        {
           
            protected void Page_Load(object sender, EventArgs e)
            {
               if (Page.IsPostBack == false)
               { 
                   int ID = 1; 
                   txtinvoiceno.Text = ID.ToString("D5");
                 }
            }
    
            protected void btnsavef1_Click(object sender, EventArgs e)
            {
                int ID = Convert.ToInt16(txtinvoiceno.Text );
                ID++;
                txtinvoiceno.Text = ID.ToString("D5");
            }
    
        }
