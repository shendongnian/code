    public class CoreEntityDirectRouteProvider : DefaultDirectRouteProvider
    {
        public CoreEntityDirectRouteProvider()
        {
            CoreEntity = Resource.CORE_ENTITY_NAME;
        }
        public string CoreEntity { get; private set; }
        protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(ActionDescriptor actionDescriptor)
        {
           
            IReadOnlyList<IDirectRouteFactory> actionRouteFactories = base.GetActionRouteFactories(actionDescriptor);
            List<IDirectRouteFactory> actionDirectRouteFactories = new List<IDirectRouteFactory>();
            foreach (IDirectRouteFactory routeFactory in actionRouteFactories)
            {
                RouteAttribute routeAttr = routeFactory as RouteAttribute;
                if (routeAttr != null && !string.IsNullOrEmpty(routeAttr.Template))
                {
                    string template = routeAttr.Template;
                    
                    if (template.Contains("{{CORE_ENTITY}}"))
                    {
                        template = template.Replace("{{CORE_ENTITY}}", CoreEntity);
                    }
                    RouteAttribute routeAttribute = new RouteAttribute(template);
                    routeAttribute.Order = routeAttr.Order;
                    routeAttribute.Name = routeAttr.Name;
                    actionDirectRouteFactories.Add(routeAttribute);
                }
            }
            return actionDirectRouteFactories.ToSafeReadOnlyCollection();
        }
    }
