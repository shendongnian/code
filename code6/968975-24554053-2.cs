    [AttributeUsage(System.AttributeTargets.Class)]
    public class WorkerAttribute : Attribute
    {
        public WorkerAttribute (String operationType)
        {
           this.OperationType = operationType; 
        }
        public String OperationType {get; private set;}
    }
    public interface IWorker { }
    [WorkerAttribute("Experienced")]
    public class ExperiencedWorker: IWorker
    {
    }
