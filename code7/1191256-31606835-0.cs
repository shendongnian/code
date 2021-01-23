    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Data.SqlClient;
    
    public partial class ExcuteScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        string sqlConnectionString = @"Initial Catalog=northwind;Data Source=subhash\SQLEXPRESS;Integrated Security=SSPI;Persist Security Info=False;";
    
        string script = File.ReadAllText(@"E:\Project Docs\TACT\northwinddata.sql");
    
        SqlConnection conn = new SqlConnection(sqlConnectionString);
    
        Server server = new Server(new ServerConnection(conn));
    
        server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
