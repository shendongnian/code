	using System;
	using System.Collections;
	using System.Linq;
	using System.Reflection;
	using System.Web.Mvc;
	using System.Web.Mvc.Routing;
	using System.Web.Routing;
	public static class RouteCollectionExtensions
	{
		public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes, string urlPrefix, object constraints)
		{
			MapLocalizedMvcAttributeRoutes(routes, urlPrefix, new RouteValueDictionary(constraints));
		}
		public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes, string urlPrefix, RouteValueDictionary constraints)
		{
			var routeCollectionRouteType = Type.GetType("System.Web.Mvc.Routing.RouteCollectionRoute, System.Web.Mvc");
			var subRouteCollectionType = Type.GetType("System.Web.Mvc.Routing.SubRouteCollection, System.Web.Mvc");
			FieldInfo subRoutesInfo = routeCollectionRouteType.GetField("_subRoutes", BindingFlags.NonPublic | BindingFlags.Instance);
			var subRoutes = Activator.CreateInstance(subRouteCollectionType);
			var routeEntries = Activator.CreateInstance(routeCollectionRouteType, subRoutes);
			// Add the route entries collection first to the route collection
			routes.Add((RouteBase)routeEntries);
			var localizedRouteTable = new RouteCollection();
			// Get a copy of the attribute routes
			localizedRouteTable.MapMvcAttributeRoutes();
			foreach (var routeBase in localizedRouteTable)
			{
				if (routeBase.GetType().Equals(routeCollectionRouteType))
				{
					// Get the value of the _subRoutes field
					var tempSubRoutes = subRoutesInfo.GetValue(routeBase);
					// Get the PropertyInfo for the Entries property
					PropertyInfo entriesInfo = subRouteCollectionType.GetProperty("Entries");
					if (entriesInfo.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
					{
						foreach (RouteEntry routeEntry in (IEnumerable)entriesInfo.GetValue(tempSubRoutes))
						{
							var route = routeEntry.Route;
							// Create the localized route
							var localizedRoute = CreateLocalizedRoute(route, urlPrefix, constraints);
							// Add the localized route entry
							var localizedRouteEntry = CreateLocalizedRouteEntry(routeEntry.Name, localizedRoute);
							AddRouteEntry(subRouteCollectionType, subRoutes, localizedRouteEntry);
							// Add the default route entry
							AddRouteEntry(subRouteCollectionType, subRoutes, routeEntry);
							// Add the localized link generation route
							var localizedLinkGenerationRoute = CreateLinkGenerationRoute(localizedRoute);
							routes.Add(localizedLinkGenerationRoute);
							// Add the default link generation route
							var linkGenerationRoute = CreateLinkGenerationRoute(route);
							routes.Add(linkGenerationRoute);
						}
					}
				}
			}
		}
		private static Route CreateLocalizedRoute(Route route, string urlPrefix, RouteValueDictionary constraints)
		{
			// Add the URL prefix
			var routeUrl = urlPrefix + route.Url;
			// Combine the constraints
			var routeConstraints = new RouteValueDictionary(constraints);
			foreach (var constraint in route.Constraints)
			{
				routeConstraints.Add(constraint.Key, constraint.Value);
			}
			return new Route(routeUrl, route.Defaults, routeConstraints, route.DataTokens, route.RouteHandler);
		}
		private static RouteEntry CreateLocalizedRouteEntry(string name, Route route)
		{
			var localizedRouteEntryName = string.IsNullOrEmpty(name) ? null : name + "_Localized";
			return new RouteEntry(localizedRouteEntryName, route);
		}
		private static void AddRouteEntry(Type subRouteCollectionType, object subRoutes, RouteEntry newEntry)
		{
			var addMethodInfo = subRouteCollectionType.GetMethod("Add");
			addMethodInfo.Invoke(subRoutes, new[] { newEntry });
		}
		private static RouteBase CreateLinkGenerationRoute(Route innerRoute)
		{
			var linkGenerationRouteType = Type.GetType("System.Web.Mvc.Routing.LinkGenerationRoute, System.Web.Mvc");
			return (RouteBase)Activator.CreateInstance(linkGenerationRouteType, innerRoute);
		}
	}
