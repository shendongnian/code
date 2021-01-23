    public class ServiceProxy : IA, IB
    {
        private ClientBase<IA> IAProxy {get;set;}
        private ClientBase<IB> IBProxy {get;set;}    
    
    
        public void IA.SomeInterfaceMethod(){   
          IAProxy.SomeInterfaceMethod();
        }
    
        public void IB.SomeInterfaceMethod(){   
          IBProxy.SomeInterfaceMethod();
        }
    }
