    Form fields, such as the following.
    Response.Write(name.Text);
    Response.Write(Request.Form["name"]);
    Query Strings
    Response.Write(Request.QueryString["name"]);
      
    Query strings, such as the following:
    Response.Write(Request.QueryString["username"]);
      
    Databases and data access methods, such as the following:
    SqlDataReader reader = cmd.ExecuteReader();
    Response.Write(reader.GetString(1));
      
    Be particularly careful with data read from a database if it is shared by other applications.
    Cookie collection, such as the following:
    Response.Write(
    Request.Cookies["name"].Values["name"]);
      
    Session and application variables, such as the following:
    Response.Write(Session["name"]);
    Response.Write(Application["name"]);
