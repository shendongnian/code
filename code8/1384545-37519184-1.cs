    public class MyBaseClass<T>
    {
        public virtual void MyMethod(T typevar)
        {
          //Do some stuff here
        }
    }
    public class MyChildClass : MyBaseClass<int>
    {
        public override void MyMethod(int typevar)
        {
            //Do you stuff
            //if you would like to call base method as well-
            base.MyMethod(typevar);
        }
    }
