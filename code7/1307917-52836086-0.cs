        <%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatchpaRegistrationpage.aspx.cs" Inherits="Employee_CatchpaRegistrationpage" %>
        
        <!DOCTYPE html>
        
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <title></title>
        </head>
        <body>
        
            <form id="form1" runat="server">
        
                <div>
        
                    <asp:ScriptManager ID="SM1" runat="server">
                    </asp:ScriptManager>
        
                    <table style="border: solid 1px black; padding: 20px; position: relative; top: 50px;"
                        align="center">
        
                        <tr>
        
                            <td>EmailID :
        
                            </td>
        
                            <td>
        
                                <asp:TextBox ID="txtEmailID" runat="server" Width="200px"></asp:TextBox>
        
                            </td>
        
                        </tr>
        
                        <tr>
        
                            <td>Password :
        
                            </td>
        
                            <td>
        
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        
                            </td>
        
                        </tr>
        
                        <tr>
        
                            <td>Confirm Password :
        
                            </td>
        
                            <td>
        
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
        
                            </td>
        
                        </tr>
        
                        <tr>
        
                            <td>Enter Below Code :
        
                            </td>
        
                            <td>
        
                                <asp:TextBox ID="txtCaptcha" runat="server" Width="200px"></asp:TextBox>
        
                            </td>
        
                        </tr>
        
                        <tr>
        
                            <td></td>
        
                            <td valign="middle">
        
                                <asp:UpdatePanel ID="UP1" runat="server">
        
                                    <ContentTemplate>
        
                                        <table>
        
                                            <tr>
        
                                                <td style="height: 50px; width: 100px;">
        
                                                    <asp:Image ID="imgCaptcha" runat="server" />
        
                                                </td>
        
                                                <td valign="middle">
        
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
        
                                                </td>
        
                                            </tr>
        
                                        </table>
        
                                    </ContentTemplate>
        
                                </asp:UpdatePanel>
        
                            </td>
        
                        </tr>
        
                        <tr>
        
                            <td colspan="2" align="center">
        
                                <asp:Button ID="btnRegiser" runat="server" Text="Register" OnClick="btnRegister_Click" />
        
                            </td>
        
                        </tr>
        
                    </table>
        
                </div>
        
            </form>
        
        </body>
        </html>
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text;
    
    
    public partial class Employee_CatchpaRegistrationpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCapctha();
            }
        }
        void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                {
                    captcha.Append(combination[random.Next(combination.Length)]);
                    Session["captcha"] = captcha.ToString();
                    imgCaptcha.ImageUrl = "CatchpaRegistrationpage.aspx?" + DateTime.Now.Ticks.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
    
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillCapctha();
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Session["captcha"].ToString() != txtCaptcha.Text)
            {
                Response.Write("Invalid Captcha Code");
            }
            else
            {
                Response.Write("Valid Captcha Code");
            }
            FillCapctha();
        }
    }
