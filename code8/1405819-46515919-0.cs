    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class ServiceProviderExtensions
        {
            public static TService AsSelf<TService>(this IServiceProvider serviceProvider)
            {
                return (TService)AsSelf(serviceProvider, typeof(TService));
            }
            public static object AsSelf(this IServiceProvider serviceProvider, Type serviceType)
            {
                var constructors = serviceType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                    .Select(o => o.GetParameters())
                    .ToArray()
                    .OrderByDescending(o => o.Length)
                    .ToArray();
                if (!constructors.Any())
                {
                    return null;
                }
                object[] arguments = ResolveParameters(serviceProvider, constructors);
                if (arguments == null)
                {
                    return null;
                }
                return Activator.CreateInstance(serviceType, arguments);
            }
            private static object[] ResolveParameters(IServiceProvider resolver, ParameterInfo[][] constructors)
            {
                foreach (ParameterInfo[] constructor in constructors)
                {
                    bool hasNull = false;
                    object[] values = new object[constructor.Length];
                    for (int i = 0; i < constructor.Length; i++)
                    {
                        var value = resolver.GetService(constructor[i].ParameterType);
                        values[i] = value;
                        if (value == null)
                        {
                            hasNull = true;
                            break;
                        }
                    }
                    if (!hasNull)
                    {
                        // found a constructor we can create.
                        return values;
                    }
                }
                return null;
            }
        }
    }
