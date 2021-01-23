    public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
            routes.MapRoute(
            	name: "GetEmployeeDetails",
            	url: "api/employeedetails",
            	defaults: new { controller = "EmployeeDetails", action = "GetEmployees" }
            );
        
            routes.MapRoute(
            	name: "GetEmployeeDetailsById",
            	url: "api/employeedetails/{employeeId}",
            	defaults: new { controller = "EmployeeDetails", action = "GetDetails", employeeId = UrlParameter.Optional }
            );
        
            routes.MapRoute(
            	name: "GetTeamMember",
            	url: "api/employeedetails/{employeeId}/teammember",
            	defaults: new { controller = "EmployeeDetails", action = "GetTeams", employeeId = UrlParameter.Optional }
            );
        
            routes.MapRoute(
            	name: "GetTeamMemberById",
            	url: "api/employeedetails/{employeeId}/teammember/{teamId}",
            	defaults: new { controller = "EmployeeDetails", action = "GetDetailsForTeam", employeeId = UrlParameter.Optional, teamId = UrlParameter.Optional }
            );
        }
    }
