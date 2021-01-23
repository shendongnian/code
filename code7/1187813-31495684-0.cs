    public class WrapperClass
    {
       public OtherClass Input;
    }
        
    public class CLass1
        {
            WrapperClass _wrapper;
            public Bind(ref WrapperClass wrapper)
            {
                    wrapper = new WrapperClass();
                    wrapper.Input = new OtherClass(); // instantiating the object
                    _wrapper = wrapper; // keeping a reference of the created object for later usage!
            }
            public void Unbind()
            {
                _wrapper.Input= null;
            }
        }
