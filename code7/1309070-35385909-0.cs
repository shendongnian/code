    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Web.Script.Serialization;
    
    namespace MyNameSpace
    {
        class Json2Wcf
        {
            private static void Main(string[] args)
            {
                Debug.WriteLine(Json2Wcf.CallWcf("{'WcfServiceClass':'MyServiceClient', 'WcfServiceAction':'Heartbeat'}"));
            }
    
            public static string CallWcf(string json)
            {
                var dict = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(json);
    
                Type typeWcfServiceClass = Type.GetType(dict["WcfServiceClass"], true);
    
                object instanceWcfServiceClass = Activator.CreateInstance(typeWcfServiceClass);
    
                MethodInfo methodWcfServiceAction = typeWcfServiceClass.GetMethod(dict["WcfServiceAction"]);
                object result = methodWcfServiceAction.Invoke(instanceWcfServiceClass, null);
    
                typeWcfServiceClass.GetMethod("Close").Invoke(instanceWcfServiceClass, null);
    
                return "Answer="+result;
            }
        }
    }
