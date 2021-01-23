    public static class ClassB<TClass>
    {
        private static ClassA RectHelper = new ClassA();
        public static void MethodB(Rect yourRect)
        {
            if (RectHelper.IsRectChanged(yourRect))
            {
                Debug.WriteLine("Changes were made");
            }
        }
    }
    public class ClassC
    {
        public void UpdateEverFrame()
        {
            ClassB<ClassC>.MethodB(new Rect(0, 0, 20, 20));
        }
    }
    public class ClassD
    {
        public void UpdateEverFrame()
        {
            ClassB<ClassD>.MethodB(new Rect(100, 100, 10, 10));
        }
    }
