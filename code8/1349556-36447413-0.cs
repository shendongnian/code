    public interface IstructionTP<T>
        where T : class
    {
        void Update(T entity);
    }
    public class ProcessIstructionTP : IstructionTP<ProcessIstructionTP>
    {
        public void Update(ProcessIstructionTP entity) 
        {
            ...
        }
    }
