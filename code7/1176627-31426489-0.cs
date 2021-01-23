    using System;
    using Microsoft.AspNet.FriendlyUrls;
    using System.Web.Routing;
    using System.Web;
    using System.Web.UI;
    using System.Web.Compilation;
     
     
    public static class MyRouteConfig
    {
       public static void RegisterRoutes(RouteCollection routes)
       {
            routes.EnableFriendlyUrls();     
            routes.MapPageRoute("superheroes", "superhero/{SuperheroName}", "~/superheroes.aspx");
            routes.MapPageRoute("languageSuperheroes", "{language}/superhero/{SuperheroName}", "~/superheroes.aspx");     
            routes.Add(new System.Web.Routing.Route("{language}/{*page}", new LanguageRouteHandler()));
      } 
         
       public class LanguageRouteHandler : IRouteHandler
       {
           public IHttpHandler GetHttpHandler(RequestContext requestContext)
           {
               string page = CheckForNullValue(requestContext.RouteData.Values["page"]);
               string virtualPath = "~/" + page;
     
               if (string.IsNullOrEmpty(page))
               {
                   string language= CheckForNullValue(requestContext.RouteData.Values["language"]);
                   string newPage = "/home";
     
                   if (!string.IsNullOrEmpty(language))
                       newPage = "/" + language + newPage;
                   HttpContext.Current.Response.Redirect(newPage, false);
                   HttpContext.Current.Response.StatusCode = 301;
                   HttpContext.Current.Response.End();
     
                  //Otherwise, route to home
                  //page = "home";
               }
     
              if (!virtualPath.Contains(".aspx"))
                    virtualPath += ".aspx";
     
               try
               {
                   return BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(Page)) as IHttpHandler;
               }
               catch
               {
                   return null;
               }
           }
       }
    }
