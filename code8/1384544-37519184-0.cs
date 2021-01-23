    public class MyBaseClass<T>
    {
        public virtual void MyMethod(T typevar)
        {
          //Do some stuff here
        }
    }
    public class MyChild : MyBaseClass<int>
    {
        public override void MyMethod(int typevar)
        {
            //Do you stuff
            base.MyMethod(typevar);
        }
    }
