    public class WorkerAttribute : Attribute
    {
        public WorkerAttribute (String operationType)
        {
           this.OperationType = operationType; 
        }
        public String OperationType {get; private set;}
    }
    
    [WorkerAttribute("Can do a lot.")]
    public MyWOrker: IWorker
    {
    }
