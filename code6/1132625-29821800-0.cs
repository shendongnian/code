    public partial class SqlDat : System.Web.UI.Page
    {
    public string P1;
    
    public SqlDat()
    { P1 = URLVariable.ToString(); }
    
    public string tb1text = "SELECT Stuff FROM Somewhere WHERE Something= "+P1;//+ HttpUtility.ParseQueryString(BaseUrl.Query).Get("Tim");
    
    }
