    public class MyBaseClass<T>
    {
        public virtual void MyMethod(T typeT)
        {
          //some important functionality
        }
    }
    public class MyChildClass : MyBaseClass<int>
    {
        public override void MyMethod(int typeInt)
        {
            //Do your stuff
            //and if you would like to call base method, use the following-
            base.MyMethod(typevar);
        }
    }
