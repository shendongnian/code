    public class AjaxResult    
    {
        
        private bool success = true;
        private List<string> messages;
        public bool Success { get { return success; } set { success = value; } }
        public List<string> Messages { get { return messages; } }
        public AjaxResult()
        {
            messages = new List<string>();
        }
    }
