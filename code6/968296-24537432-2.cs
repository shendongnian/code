    public class UnityActionAdapter : IAction
    {
        private readonly IUnityAction UnityAction;
    
        public UnityActionAdapter(IAction unityAction)
        {
            UnityAction = action;
        }
    
        public void Execute()
        {
            StartCoroutine(UnityAction.Execute()); //If I'm correctly understanding how you'd execute an action here
        }
    }
