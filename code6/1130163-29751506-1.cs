    interface IMyRepository {
        
       void Save(MyComplexBussinessAgg aggregate);
    
    }
    class MyRepository: IMyRepository {
       public void Save(MyComplexBussinessAgg aggregate) {
          //Pseudo Code
          //1.- Check valid state of MyComplexBusinessAgg
          //2.- Transform to a persistence-friendly DTO
          //3.- Persist
       }
       
    }
