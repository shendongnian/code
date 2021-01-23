    public delegate void ActionHandler<TAction>(TAction parameter);
    
    public abstract class ActionIssuer<TAction>
    {
        public void Subscribe(ActionHandler<TAction> handler) { ... }
        ...
    }
