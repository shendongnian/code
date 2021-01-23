    using System.Configuration;
    using System.ServiceModel.Configuration;
    
        public static void ApplyEndpointBehavior(ServiceEndpoint serviceEndpoint, string behaviorName)
        {
            EndpointBehaviorElement endpointBehaviorElement = GetEndpointBehaviorElement(behaviorName);
            if (endpointBehaviorElement == null) return;
            List<IEndpointBehavior> list = CreateBehaviors<IEndpointBehavior>(endpointBehaviorElement);
            foreach (IEndpointBehavior behavior in list)
            {
                Type behaviorType = behavior.GetType();
                if (serviceEndpoint.Behaviors.Contains(behaviorType))
                {
                    serviceEndpoint.Behaviors.Remove(behaviorType);
                }
                serviceEndpoint.Behaviors.Add(behavior);
            }
        }
        public static EndpointBehaviorElement GetEndpointBehaviorElement(string behaviorName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup sectionGroup = ServiceModelSectionGroup.GetSectionGroup(config);
            if (sectionGroup == null || !sectionGroup.Behaviors.EndpointBehaviors.ContainsKey(behaviorName))
                return null;
            return sectionGroup.Behaviors.EndpointBehaviors[behaviorName];
        }
        public static List<T> CreateBehaviors<T>(EndpointBehaviorElement behaviorElement) where T : class
        {
            List<T> list = new List<T>();
            foreach (BehaviorExtensionElement behaviorSection in behaviorElement)
            {
                MethodInfo info = behaviorSection.GetType().GetMethod("CreateBehavior", BindingFlags.NonPublic | BindingFlags.Instance);
                T behavior = info.Invoke(behaviorSection, null) as T;
                if (behavior != null)
                {
                    list.Add(behavior);
                }
            }
            return list;
        }
