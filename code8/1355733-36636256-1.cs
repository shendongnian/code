    public class MyDependentClass {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
    
        public MyDependentClass (IUnitOfWorkFactory unitOfWorkFactory) {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    
        public IEnumerable<MyClass> MyMethod() {
             using (var _unitOfWork = unitOfWorkFactory.Create()) {
                 var myEntities= _unitOfWork.MyEntityRepository.Get();
    
                 var result = ... some logic to convert myEntities collection to IEnumerable<MyClass> 
                 return result;
             }
        }
    }
