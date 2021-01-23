    using BaseClass; //use the namespace you defined BaseClass in
    namespace DerivedClass
    {
        public partial class DerivedClass : BaseClass
        {
            public void MyValueClass()
            {
                this.ValueClass();
            }
        }
    }
