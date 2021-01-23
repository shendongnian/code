    public class CustomTask : Task
    {
        private Action m_action;
    
        public Action Action
        {
            get { return m_action; }
        }
                
        public CustomTask(Action action) : base(action)
        {
            m_action = action;
        }
    }
