    public abstract class AbstractClass
    {
        public event Action ActionEvent;
        protected bool EventIsNull()
        {
            return ActionEvent == null; 
        }
    }
    public class MyClass : AbstractClass
    {
        private void SomeMethod()
        {
            //Want to access ActionEvent-- Now you can!
            if (!EventIsNull())
            {}
        }
    }
