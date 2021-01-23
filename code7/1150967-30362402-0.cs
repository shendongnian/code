        public class T1
    {
        public string customVariablePageName1 { get; set; }
        public string customVariablePageValue1 { get; set; }
    }
    
    public class CustomVariables
    {
        public T1 t1 { get; set; }
    }
    
    public class ActionDetail
    {
        public string type { get; set; }
        public string url { get; set; }
        public CustomVariables customVariables { get; set; }
        public string timeSpent { get; set; }
    }
    
    public class RootObject
    {
        public string idSite { get; set; }
        public string visitorId { get; set; }
        public List<ActionDetail> actionDetails { get; set; }
    }
 
