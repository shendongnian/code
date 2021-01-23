    // You need this reference to System.Web.Configuration.dll
    // and remove the using System.Configuration;
    using System.Web.Configuration;
    ....
    string cons = WebConfiguration.ConnectionStrings["ConnectionString"].ConnectionString;
    using(SqlConnection cnn = new SqlConnection(cons))
    .....
