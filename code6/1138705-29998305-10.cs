    <%@ Page Language="C#" AutoEventWireup="true"  %>
    <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Suppress it all!");
        Response.SuppressContent = true;
    }
    </script>
    Dynamic Content
    <%= DateTime.Now %>
