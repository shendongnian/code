    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <cc1:AutoCompleteExtender ServiceMethod="GetCompletionList" 
                ServicePath="WebService1.asmx"                
                MinimumPrefixLength="0" 
                CompletionInterval="100" 
                ID="AutoCompleteExtender1"
                runat="server" 
                TargetControlID="TextBox1"></cc1:AutoCompleteExtender>
        </div>
        </form>
    </body>
    </html>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    namespace TestWebSite
    {
        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {
            [WebMethod]
            public string[] GetCompletionList(string prefixText, int count)//, string contextKey)
            {
                string[] s = { "a", "b", "c", "d" };
                return s;
            }
        }
    }
    //List<string> works just as well as string[]
