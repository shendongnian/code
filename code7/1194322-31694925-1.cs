    namespace DerivedClass
    {
        //use the fully qualified name for BaseClass:
        public partial class DerivedClass : BaseClass.BaseClass
        {
            public void MyValueClass()
            {
                this.ValueClass();
            }
        }
    }
