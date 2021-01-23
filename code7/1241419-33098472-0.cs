     public partial class Default : System.Web.UI.Page
     {
        int dbCompany = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page Load event
        }
        protected void gdDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbCompany = Convert.ToInt32(gdDisplay.SelectedRow.Cells[2].Text);
        }
        void gvFunction_Update()
        {
            int x = dbCompany ;
        }
     }
    
    
