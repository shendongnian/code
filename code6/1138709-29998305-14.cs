    <%@ Page Language="C#" AutoEventWireup="true"  %>
    <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/SomewhereElse.aspx", false);
        Response.Write("Redirect Supress Content");
        Response.SuppressContent = true;
    }
    </script>
    Dynamic Content
    <%= DateTime.Now %>
    
