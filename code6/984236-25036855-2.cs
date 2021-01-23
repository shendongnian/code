    <%@ Page 
        Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master" 
        Inherits="System.Web.Mvc.ViewPage<AppName.Models.MyViewModel>" 
    %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <% using (Html.BeginForm()) { %>
            <%= Html.DropDownListFor(x => x.ValueId, Model.Values) %>
            <br/>
            <%= Html.EditorFor(x => x.NewValue) %>
            <%= Html.ActionLink("Suggest Value", "New", "NewValue", null, new { id = "new-value-link" }) %>
            <button type="submit">OK</button>
        <% } %>
    
        <div id="dialog"></div>
    
    </asp:Content>
