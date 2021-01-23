        <!DOCTYPE html>
        
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">  
        </head>  
        <body>  
            <form runat="server" id="form1">
           <asp:Menu OnMenuItemClick="Menu1_MenuItemClick" ID="mini" runat="server" Orientation="Horizontal">
                  <Items> <asp:MenuItem Text="Item">
                      <asp:MenuItem Text="GetUser" Value="1">
                          <asp:MenuItem Text="MenuSub" Value="MenuSub" ></asp:MenuItem>
                          <asp:MenuItem Text="MenuSub1" Value="MenuSub1" ></asp:MenuItem>
                      </asp:MenuItem>
                      <asp:MenuItem Text="Item" Value="Item">
                          <asp:MenuItem Text="MenuSub" Value="MenuSub"></asp:MenuItem>
                      </asp:MenuItem>
                      </asp:MenuItem></Items>
              </asp:Menu>
        
                 <asp:GridView ID="GridView1" CssClass="table-condensed" runat="server" DataKeyNames="projectid" >
                <Columns>
                <asp:TemplateField HeaderText="Proje">
                <ItemTemplate>
                <asp:Label ID="lbfid" runat="server" Text='<%#Eval("projectid")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
        
                <asp:TemplateField HeaderText="Doc">
                <ItemTemplate>
                <asp:Label ID="lbfname" runat="server" Text='<%#Eval("video")%>'></asp:Label>
                    <asp:HyperLink runat="server" CommandName="view" CommandArgument='<%#Eval("abstract")%>' >download</asp:HyperLink>
        
                </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
        
            </asp:GridView>
                </form>
             
        </body>  
        </html>  
        
        
       using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class AutoCompleteCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection("Your database connection");
            if(mini.SelectedItem.Value=="1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [order]",conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
