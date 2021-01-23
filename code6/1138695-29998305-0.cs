    <%@ Page Language="C#" AutoEventWireup="true"  %>
    <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("No Supression");
    }
    </script>
    Dynamic Content
    <%= DateTime.Now %>
