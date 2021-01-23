    <%@ Page Language="C#" AutoEventWireup="true" %>
    <%@ Import Namespace="System" %>
    <%@ Import Namespace="System.Web" %>
    <%@ Import Namespace="System.Web.UI" %>
    <%@ Import Namespace="System.Web.UI.WebControls" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script type="text/C#" runat="server">
            protected void btnTest_Click(object sender, EventArgs e)
            {
                System.Web.UI.WebControls.Label lblTest = FindControl("lblTest") as System.Web.UI.WebControls.Label;
                lblTest.Text = "Test";
            }
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblTest"></asp:Label>
            <asp:Button runat="server" ID="btnTest" OnClick="btnTest_Click" Text="test" />
        </div>
        </form>
    </body>
    </html>
