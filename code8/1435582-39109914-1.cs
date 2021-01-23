    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
    <%@ Import Namespace="System.Xml" %>
    
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <table>
        <% foreach ( XmlNode book in myNodes) { %>
                <tr>
                <% foreach ( XmlNode childElement in book ) {
                       string title = null;
                       string year = null;
                       string price = null;
                       List<string> authors = new List<string>();
                       
                       switch (childElement.Name)
                       {
                           case "title":
                               title = childElement.InnerText.ToString();
                               break;
                           case "year":
                               year = childElement.InnerText.ToString();
                               break;
                           case "price":
                               price = childElement.InnerText.ToString();
                               break;
                           case "authors":
                               foreach (XmlNode grandChildElement in childElement)
                               {
                                   authors.Add(grandChildElement.InnerText);
                               }
                               break;
                       }%>
    
                        <td><label><%= title %></label></td>
                        <td><label><%= year %></label></td>
                        <td><label><%= price %></label></td>
                        <td>
                            <%foreach( string author in authors ){ %>
                                <label> <%= author %></label><br />
                            <% } %>
                        </td>
                <% } %>
                </tr>
        <% } %>
        </table>
    </asp:Content>
