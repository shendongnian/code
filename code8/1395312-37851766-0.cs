    public class clsSingleton
    {
        private static clsSingleton instance = null;        
        clsSingleton()
        {
        }
        public static clsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new clsSingleton();
                }
            }
        }
        public string GetName()
        {
            return "Name";
        }
    }
