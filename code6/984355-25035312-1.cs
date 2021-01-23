    public partial class Database : System.Web.UI.Page
    {
       public OleDbConnection cn=new OleDbConnection(@"
                               Provider=Microsoft.Jet.OLEDB.4.0;
                               Data Source=C:\Documents and 
                               Settings\jSte\Desktop\database_1.mdb; 
                               Integrated Security=true; User Instance =true; 
                               Persist Security Info=True");  
       protected void Page_Load(object sender, EventArgs e)
       {
          OleDbCommand cmd = new OleDbCommand("SELECT * from CustomerDetails", cn);
          OleDbDataAdapter ad = new OleDbDataAdapter (cmd);
          DataSet ds = new DataSet();
          ad.Fill(ds);
          GridView1.DataSource = ds;
          GridView1.DataBind();
       }
     }
