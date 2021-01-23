    protected void Page_Load(object sender, EventArgs e)
            {
               LoadJavascript(Page);
            }
 
    public static void LoadJavascript( Page page)
            {
                
               page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "<script>alert('Hai');</script>");
            }
