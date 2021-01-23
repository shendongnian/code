    using System.Reflection;
    ...
            foreach (var attribute in this.GetType().GetTypeInfo().Assembly.CustomAttributes)
            {
                Debug.WriteLine(attribute);
            }
