    // An instance of this class will Do After
    public class MyClass : ThirdPartyClass 
    {
        public virtual void SpecialFunction() 
        { 
           // All the work goes here
        }
    }
    // An instance of this class will Do First
    public class MyClassPre : MyClass 
    {
        [DoFirst]
        public override void SpecialFunction() 
        {
            base.SpecialFunction();
        }
    }
