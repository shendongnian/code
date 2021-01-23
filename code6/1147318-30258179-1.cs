    public static class Paths
    {
        public static string Path1 = "";
        public static string Path2 = "";
    }
    
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NavigationTargetAttribute : Attribute
    {
        public string Target { get; set; }
    
        public NavigationTargetAttribute(string target)
        {
            Target = target;
        }
    }
    
    public class MyNavigationClass
    {
        [NavigationTarget(Paths.Path1)]
        public void MyNavigateMethod()
        {
            string target = GetNavigationTarget();
        }
    
        private string GetNavigationTarget([CallerMemberName]string caller = null)
        {
            object[] attribs = this.GetType()
                                   .GetMethod(caller)
                                   .GetCustomAttributes(
                                   typeof(NavigationTargetAttribute), false);
    
            if (attribs == null)
                return "some default target";
    
            return ((NavigationTargetAttribute)attrib[0]).Target;
        }
    }
