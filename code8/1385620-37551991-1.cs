    public static  MvcHtmlString ActionBaseRole(this HtmlHelper value, string actionName, string controllerName, object routeValues , IPrincipal user)
     {     
       bool userHasRequeredRole = false;
       Type t = Type.GetType((string.Format("MyProject.Controllers.{0}Controller",controllerName))); // MyProject.Controllers... replace on you namespace
       MethodInfo method = t.GetMethod(actionName);
       var attr = (method.GetCustomAttribute(typeof(AuthorizeAttribute), true) as AuthorizeAttribute);
       if (attr != null)
       {
          string[] methodRequeredRoles = attr.Roles.Split(',');
          userHasRequeredRole = methodRequeredRoles.Any(r => user.IsInRole(r.Trim())); // user roles check in depends on implementation authorization in you site  
                                                                                                // In a simple version that might look like                                                                         
       }
       else userHasRequeredRole = true; //method don't have Authorize Attribute
       return userHasRequeredRole ? value.Action(actionName, controllerName, routeValues) : MvcHtmlString.Empty; 
     }
