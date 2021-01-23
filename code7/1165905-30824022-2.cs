    using System;
    using System.Web.Script.Serialization;
    using System.Web.UI;
    namespace WebApplication1
    {
        public partial class WebForm1 : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var filter = @"[['Title', 'contains', 'foo'],'and',['Name','contains','foo']]";
                var serializedArray = new JavaScriptSerializer().Deserialize<object[]>(filter);
                foreach (var item in serializedArray)
                {
                    if (item is string)
                    {
                        Response.Write(item + "<br/>");
                    }
                    else
                    {
                        foreach (var innerItem in (object[])item)
                        {
                            Response.Write(innerItem + "<br/>");
                        }
                    }
                }
            }
        }
    }
