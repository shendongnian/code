    public class Messaging 
    {
        private static string dLMessage;
        public static string DLMessage
        {
            get { return dLMessage; }
            set
            {
                if (value != dLMessage)
                {
                    dLMessage = value;
                    OnDLMessageChanged(EventArgs.Empty);
                }
            }
        }
        protected static void OnDLMessageChanged(EventArgs e)
        {
            EventHandler handler = DLMessageChanged;
            if (handler != null)
                handler(null, e);
        }
        public static event EventHandler DLMessageChanged;
    }
