    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
    <%@ Import Namespace="System.Xml" %>
    
    
    
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="myGridView_RowDataBound" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <label> Title: <%# Eval("title")%></label>
                         <label> Year:<%# Eval("year")%></label>
                         <label> Price:<%# Eval("price")%></label>
                         <asp:Repeater ID="myRepeater" runat="server">
                              <HeaderTemplate>
                                <table>
                                    <thead>Authors: </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="myLabel" runat="server"><%# Eval("author_Text")%></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                                <br />
                            </FooterTemplate>
                         </asp:Repeater>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
        </asp:GridView>
    </asp:Content>
