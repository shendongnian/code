    using Newtonsoft.Json.Linq;
    using System;
    using System.Reflection;
    
    public static class BackgroundJobHelper
    {
        public static object Execute(string userId, Type classType, string functionName, object[] param)
        {
            ServiceFactory serviceFactory = new ServiceFactory(userId);
            var classToInvoke = Activator.CreateInstance(classType, new object[] { serviceFactory });
            return Send(classType, classToInvoke, functionName, param);
        }
    
        private static object Send(Type classType, object className, string functionName, object[] param, Type[] fnParameterTypes = null)
        {
            MethodInfo methodInfo;
            if (!fnParameterTypes.IsNullOrEmpty())
            {
                methodInfo = classType.GetMethod(functionName, fnParameterTypes);
            }
            else
            {
                methodInfo = classType.GetMethod(functionName);
            }
            var methodParameters = methodInfo.GetParameters();
            //Object of type 'System.Int64' cannot be converted to type 'System.Int32'. While deserializing int is converted into long hence explictly make it Int32.
            for (int i = 0; i < param.Length; i++)
            {
                var methodParameterType = methodParameters[i].ParameterType;
                if (param[i] != null)
                {
                    if (param[i] is long l)
                    {
                        if (l >= int.MinValue && l <= int.MaxValue) param[i] = (int)l;
                    }
                    else if (param[i].GetType() == typeof(JObject))
                    {
                        param[i] = (param[i] as JObject).ToObject(methodParameterType);
                    }
                    else if (param[i].GetType() == typeof(JArray))
                    {
                        param[i] = (param[i] as JArray).ToObject(methodParameterType);
                    }
                }
            }
            return methodInfo.Invoke(className, param);
        }
    }
