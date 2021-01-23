    public partial class Default_T : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusiness objBusiness = new clsBusiness();
        GridView1.DataSource = objBusiness.LoadCustomer();
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clsBusiness objBusiness = new clsBusiness();
        objBusiness.AddNewUser(Request.Form["Text1"], Request.Form["Text2"]);
        clearAll();
        Response.Redirect("Default.aspx");
    }
    public void clearAll()
    {
        Request.Form["Text1"] = "";
        Request.Form["Text2"] = "";
    }
