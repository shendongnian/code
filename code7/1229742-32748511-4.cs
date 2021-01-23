    public class ClassA
    {
        private ChangeChecker value = new ChangeChecker();
        public void MethodA(Rect area)
        {
            if (value.Changed(area))
            {
                Debug.Log("ChangeMade");
            }
        }
    }
    public class ClassB
    {
        private readonly ClassA m_ClassAInstance = new ClassA();
        void Update()
        {
            m_ClassAInstance.MethodA(new Rect(2, 2, 20, 20));
        }
    }
    public class ClassC
    {
        private readonly ClassA m_ClassAInstance = new ClassA();
        void Update()
        {
            m_ClassAInstance.MethodA(new Rect(0, 100, 100, 100));
        }
    }
