    public class MyClass
    {
        private readonly Func<UnitOfWork> unitOfWorkFactory;
    
        public MyClass(Func<UnitOfWork> unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    
        public IEnumerable<MyClass> MyMethod()
        {
            using (unitOfWork = unitOfWorkFactory())
            {
                //..
            }
        }
    }
