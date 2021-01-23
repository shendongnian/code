    public class Service
    {
        public string Name { get; set; }
        public List<Service> ChildServices{ get; set; }
    
        public List<Action> AvailableActions{ get; set; }
    }
    
    public class Action
    {
        public string Name { get; set; }
        public List<string> Parameters{ get; set; }
    
        public void Execute()
        {
           
        }
    }
    
    public static class Extensions
    {
    	public static IEnumerable<Service> GetAllServices(this Service node)
        {
            yield return node;
            if(node.ChildServices != null)
            {
                foreach(var child in node.ChildServices)
                {
                    foreach(var childOrDescendant in child.GetAllServices())
                    {
                        yield return childOrDescendant;
                    }
                }
            }
        }
    }
