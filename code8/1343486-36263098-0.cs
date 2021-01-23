    <%@ Page Language="C#" %>
    <%@ Reference Control="~/Controls/Spinner.ascx" %>    
    <script runat="server">
    private ASP.Spinner Spinner1
    
    protected void Page_Load(object sender, EventArgs e)
    {
       Spinner1 = (ASP.Spinner)LoadControl("~/Controls/Spinner.ascx");
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        PlaceHolder1.Controls.Add(Spinner1);
    }
    </script>
