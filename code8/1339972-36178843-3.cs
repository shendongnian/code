        @{
            var locales = new Dictionary<string, string>() { { "en", "eng" }, { "ru", "rus" } };            
            
            var controller = Url.RequestContext.RouteData.Values["controller"].ToString();
            var action = Url.RequestContext.RouteData.Values["action"].ToString();
            var id = Url.RequestContext.RouteData.Values["id"];
            
        }
        <ul id="changeLang">            
            @foreach (var l in locales) {
                <li>@Html.ActionLink(l.Value, action, controller, new { lang = l.Key, id = id}, null)</li>
            }
        </ul>
        @RenderBody()
