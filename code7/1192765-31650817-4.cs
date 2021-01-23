	<%@ Application Language="C#" %>
	<script runat="server">
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteTable.Routes.MapRoute(
				"HelloWorld", // Route name
				"{action}", // URL with parameters
                null
			);
		}
	</script>
