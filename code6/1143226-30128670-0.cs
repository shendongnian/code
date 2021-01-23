    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChildPage.aspx.cs" Inherits="ChildPage" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <asp:UpdatePanel ID="MyUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </ContentTemplate>
    
        </asp:UpdatePanel>
    
    
    </asp:Content>
    public partial class ChildPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label newLabel = new Label
            {
                Text = "Label",
                Width = 200,
                Height = 150,
            };
            newLabel.Text = "Label: " + DateTime.Now.ToString();
    
            PlaceHolder1.Controls.Add(newLabel);       
        }
    }
