cs
using System;
using System.Linq;
namespace IOC
{
    /// <summary>
    /// Ioc Container
    /// </summary>
    public class Container
    {
        private readonly System.Collections.Generic.Dictionary<Type, Type> map = new System.Collections.Generic.Dictionary<Type, Type>();
        public string Name { get; private set; }
        public Container(string containerName)
        {
            Name = containerName;
            System.Diagnostics.Trace.TraceInformation("New instance of {0} created", Name);
        }
        /// <summary>
        /// Register the mapping for inversion of control
        /// </summary>
        /// <typeparam name="From">Interface </typeparam>
        /// <typeparam name="To">Insatnce</typeparam>
        public void Register<From,To>()
        {
            try
            {
                map.Add(typeof(From), typeof(To));
                System.Diagnostics.Trace.TraceInformation("Registering {0} for {1}", typeof(From).Name, typeof(To).Name);
            }
            catch(Exception registerException)
            {
                System.Diagnostics.Trace.TraceError("Mapping Exception", registerException);
                throw new IocException("Mapping Exception",registerException);
            }
        }
        /// <summary>
        /// Resolves the Instance 
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
        private object Resolve(Type type)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = map[type];
                System.Diagnostics.Trace.TraceInformation("Resolving {0}", type.Name);
            }
            catch(Exception resolveException)
            {
                System.Diagnostics.Trace.TraceError("Could't resolve type", resolveException);
                throw new IocException("Could't resolve type", resolveException);
            }
            var ctor = resolvedType.GetConstructors().First();
            var ctorParameters = ctor.GetParameters();
            if(ctorParameters.Length ==0)
            {
                System.Diagnostics.Trace.TraceInformation("Constructor have no parameters");
                return Activator.CreateInstance(resolvedType);
            }
            var parameters = new System.Collections.Generic.List<object>();
            System.Diagnostics.Trace.TraceInformation("Constructor found to have {0} parameters",ctorParameters.Length);
            foreach (var p in ctorParameters)
            {
                parameters.Add(Resolve(p.ParameterType));
            }
            return ctor.Invoke(parameters.ToArray());
        }
    }
}
