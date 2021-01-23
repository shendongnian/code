    public class InheritedPublicClass : PublicClass
    {
        public void MyPublicMethod()
        {
            PublicMethod();     //Calls base class method
            ProtectedMethod();  //Calls base class method
            PrivateMethod();    //Invalid, not accessible
        }
    }
