    private IEnumerable<string> GetKnownTypes()
        {
            List<string> result = new List<string>();
            Type interfaceType = typeof(IMyInterface);
            IEnumerable<CustomAttributeData> attributes = interfaceType.CustomAttributes
                .Where(t => t.AttributeType == typeof(ServiceKnownTypeAttribute));
            foreach (CustomAttributeData attribute in attributes)
            {
                IEnumerable<CustomAttributeTypedArgument> knownTypes = attribute.ConstructorArguments;
                foreach (CustomAttributeTypedArgument knownType in knownTypes)
                {
                    result.Add(knownType.Value.ToString());
                }
            }
            result.Sort();
            return result;
        }
