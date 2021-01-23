	public class DynamicNavigationRoutingConvention : NavigationSourceRoutingConvention
	{
		public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
		{
			if (controllerContext.Request.Method != HttpMethod.Get || odataPath.PathTemplate != "~/entityset/key/navigation")
			{
				return null;
			}
			NavigationPathSegment navigationSegment = odataPath.Segments.Last() as NavigationPathSegment;
			IEdmNavigationProperty navigationProperty = navigationSegment.NavigationProperty;
			IEdmEntityType declaringType = navigationProperty.DeclaringType as IEdmEntityType;
			if (declaringType == null)
			{
				return null;
			}
			string actionName = navigationProperty.TargetMultiplicity() == EdmMultiplicity.Many
				? "GetRelatedEntityCollection" : "GetRelatedSingleEntity";
			
			if (!actionMap.Contains(actionName))
			{
				return null;
			}
			KeyValuePathSegment keyValueSegment = odataPath.Segments[1] as KeyValuePathSegment;
			controllerContext.RouteData.Values[ODataRouteConstants.Key] = keyValueSegment.Value;
            // Add information about the specific navigation property. If you need
            // more than just the name, add additional items to RouteData.Values.
			controllerContext.RouteData.Values["navigationProperty"] = navigationProperty.Name;
			return actionName;
		}
	}
