    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Security.Permissions;
    using Infrastructure.Prism.Attributes;
    using Microsoft.Practices.Prism.Modularity;
     namespace Infrastructure.Prism.ModuleCatalog
     {
    [SecurityPermission(SecurityAction.InheritanceDemand),   SecurityPermission(SecurityAction.LinkDemand)]
    public class PrioritisedDirectoryModuleCatalog : DirectoryModuleCatalog
    {
        /// <summary>
        /// load assemblies into different AppDomain, which is then discarded
        /// </summary>
        class ModulePriorityLoader : MarshalByRefObject
        {
            /// <summary>
            /// Get the priority attribute of each module
            /// </summary>
            /// <param name="modules"></param>
            /// <returns></returns>
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic"),
            SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods"
            , MessageId = "System.Reflection.Assembly.LoadFrom")]
            public Dictionary<string, int> GetPriorities(IEnumerable<ModuleInfo> modules)
            {
                var priorities = new Dictionary<string, int>();
                var assemblies = new Dictionary<string, Assembly>();
                foreach (ModuleInfo module in modules)
                {
                    if (!assemblies.ContainsKey(module.Ref))
                    {
                        assemblies.Add(module.Ref, Assembly.LoadFrom(module.Ref));
                        //assemblies.Add(module.Ref, Assembly.ReflectionOnlyLoadFrom(module.Ref));
                    }
                    Type type = assemblies[module.Ref].GetExportedTypes()
                                .Where(p => p.AssemblyQualifiedName
                                .Equals(module.ModuleType, StringComparison.Ordinal)).First();
                    var priorityAttribute = CustomAttributeData.GetCustomAttributes(type)
                                           .FirstOrDefault(p => p.Constructor
                                           .DeclaringType.FullName == typeof(PriorityAttribute).FullName);
                    int priority = (priorityAttribute != null) ? (int)priorityAttribute.ConstructorArguments[0].Value : 0;
                    priorities.Add(module.ModuleName, priority);
                }
                return priorities;
            }
        }
        /// <summary>
        /// Get priority of each module, assign 0 if no priority assigned
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        private Dictionary<string, int> GetModulePriorities(IEnumerable<ModuleInfo> modules)
        {
            AppDomain childDomain = BuildChildDomain(AppDomain.CurrentDomain);
            try
            {
                Type loaderType = typeof(ModulePriorityLoader);
                var loader = (ModulePriorityLoader)childDomain
                            .CreateInstanceFrom(loaderType.Assembly.Location, 
                            loaderType.FullName).Unwrap();
                return loader.GetPriorities(modules);
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }
        /// <summary>
        /// Sort modules according to dependencies and priority
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        protected override IEnumerable<ModuleInfo> Sort(IEnumerable<ModuleInfo> modules)
        {
            Dictionary<string, int> priorities = GetModulePriorities(modules);
            var result = new List<ModuleInfo>(base.Sort(modules));
            result.Sort((x, y) =>
            {
                return GetModulePriority(x, y, priorities);
            });
            return result;
        }
        private int GetModulePriority(ModuleInfo x, ModuleInfo y, 
        Dictionary<string, int> priorities)
        {
            var f2 = 0;
            string xModuleName = x.ModuleName;
            string yModuleName = y.ModuleName;
            if (x.DependsOn.Contains(yModuleName))
            {
                f2 = 1;
            }
            else if (y.DependsOn.Contains(xModuleName))
            {
                f2 = -1;
            }
            else
            {
                f2 = priorities[xModuleName].CompareTo(priorities[yModuleName]);
            }
            return f2;
        }
    }
    }
