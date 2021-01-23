    public interface IAction
    {
        void Execute();
    }
    
    public interface IUnityAction
    {
        IEnumerator Execute();
    }
    
    public class UnityActionAdapter : IUnityAction
    {
        private readonly IAction Action;
    
        public UnityActionAdapter(IAction action)
        {
            Action = action;
        }
    
        public IEnumerator Execute()
        {
            Action.Execute();
            yield break; //Or whatever you need to yield here
        }
    }
