    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) bindListBox();
    }
    private void bindListBox()
    {
        ddlProduct.DataSource = getReader();
        ddlProduct.DataTextField = "name";
        ddlProduct.DataValueField = "IdAndName";
        ddlProduct.DataBind();
    }
    private SqlDataReader getReader()
    {
        //get connection string from web.config
        string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "SELECT Id,Name,CAST( id as nvarchar(10) )+'-'+Name as IdAndName  FROM  Product";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        myConnect.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = "";
        Label1.Text += "productName:" + ddlProduct.SelectedItem.Text + "<br/>";
        Label2.Text = "";
        Label2.Text += "IDANDPRICE:" + ddlProduct.SelectedItem.Value;
    }
   
    }
