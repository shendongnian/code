    public class ClassB
    {
        public void Update()
        {
            ClassA.MethodA(new Rect(2, 2, 20, 20), this);
        }
    }
    public class ClassC
    {
        public void Update()
        {
            ClassA.MethodA(new Rect(0, 100, 100, 100), this);
        }
    }
