     public class GenericRoutes
     {
     public string Controller {get;set;}
     public string Action {get;set;}
     public string Url{get;set;}
     public string RouteName{get;set;}
     }
     
     Public List<GenericRoutes> Routes = new List<GenericRoutes>();
    Routes.Add(new GenericRoutes{Cotroller="bl",Action="cl",Url="bl/cl"})
    For(int i=0;i<Routes.count();i++){
       routes.MapRoute(
     Routes[i].RouteName,
     Routes[i].Url
     new { controller = Routes[i].Controller, action = Routes[i].Action },
     );
    }
