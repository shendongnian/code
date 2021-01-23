    public class WorkerAttribute : Attribute
    {
        ...
        public String OperationType {get; private set;}
    }
    
    [WorkerAttribute("Can do a lot.")]
    public MyWOrker: IWorker
    {
    }
