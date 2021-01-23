    public class SecondClassWithGeneric<U>
    {
        public void getNestedObject()
        {
             var type = typeof(U).GetGenericArguments()[0].GetGenericArguments()[0];
        }
    }
