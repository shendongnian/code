    <%@ Page Language="C#" AutoEventWireup="true"  %>
    <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/SomewhereElse.aspx");
        // Exception was thrown by previous statement. These two lines do not run.
        Response.Write("Redirect Supress Content");
        Response.SuppressContent = true;
    }
    </script>
    Dynamic Content
    <%= DateTime.Now %>
    
