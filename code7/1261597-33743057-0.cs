    public class TestClass : ParentClass
    {
        public event EventHandler<string> MyDelegate;
        
        public class TestClass(Action<string> myAction)
        {
          MyDelegate += myAction;
        }
        public override void OnAction(Context context, Intent intent)
        {
            var handler = MyDelegate;
            if (handler != null)
            {
                handler(this, "test");
            }
        }
    }
