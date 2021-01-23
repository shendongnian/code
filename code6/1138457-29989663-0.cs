    public class GetControllerNameSpace
    {
        public static string NamespaceTag; 
        public void GetControllerNameSpaceMethod()
        {
            var NamespaceTagList = this.GetType().Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Controller))).Select(x => x.Namespace).Distinct().ToList();
            NamespaceTag = NamespaceTagList.FirstOrDefault();
        }
    }
