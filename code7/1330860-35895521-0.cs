    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace Main
    {
        public class LocalSystem
        {
            // Use this to store the list of classes/methods. bool is redundant
            public static Dictionary<Tuple<string, string>, bool> classMethods = new Dictionary<Tuple<string, string>, bool>();
    
            // Singleton
            private static LocalSystem instance;
    
            public static LocalSystem Instance
            {
                get
                {
                    if (instance == null)
                    {
                        GetAssemblies();    // We do this once. I suspect this to be slow.
                        instance = new LocalSystem();
                    }
    
                    return instance;
                }
            }
    
            // Editor specific callers
            public void InvokeEditorMethod(string methodName)                               // Call function
            {
                invokeClassMethod("Main.Editor", methodName, null);
            }
    
            public void InvokeEditorMethod(string methodName, params object[] values)       // Call function with some arguments
            {
                invokeClassMethod("Main.Editor", methodName, values);
            }
    
            // This tries to invoke the class.method
            private void invokeClassMethod(string className, string methodName, params object[] values)
            {
                if (!ClassHasMethod(className, methodName))     // We check if the class name and method exist. If not, we bail out.
                    return;
    
                try
                {
                    Type.GetType(className).GetMethod(methodName).Invoke(null, values);
                }
                catch(Exception e)
                {
                    if (e is TargetParameterCountException)     // This error might be more common than others
                    {
                        throw new Exception("Wrong number of parameters (" + values.Count() + ") provided for method " + methodName + " within " + className);
                    }
                    throw e;    // Something else went wrong
                }
                
            }
    
            private static void GetAssemblies()
            {
                Assembly asm = Assembly.GetExecutingAssembly();
    
                foreach (Type type in asm.GetTypes())
                {
                    string discoveredClass = type.FullName;
                    foreach (MethodInfo method in Type.GetType(discoveredClass).GetMethods())
                    {
                        if (!classMethods.ContainsKey(new Tuple<string, string>(discoveredClass, method.Name)))
                            classMethods.Add(new Tuple<string, string>(discoveredClass, method.Name), true);
                    }
                }
            }
    
            private static bool ClassHasMethod(string className, string methodName)
            {
                return classMethods.ContainsKey(new Tuple<string, string>(className, methodName));
            }
    
        }
    }
