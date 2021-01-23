    public abstract class AbstractClass
    {
        public abstract event Action ActionEvent;
    }
    public class MyClass : AbstractClass
    {
        public override event Action ActionEvent;
        private void SomeMethod()
        {
            //Want to access ActionEvent-- Now you can!
            if (ActionEvent != null)
            {
            }
        }
    }
