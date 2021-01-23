    private readonly LinkedList<ConditionalAction> pendingConditionalActions = 
        new LinkedList<ConditionalAction>();
    public void Update(GameTime time)
    {
        for (var current = pendingConditionalActions.First; current != null; current = current.Next)
        {
            if (current.Value.Predicate())
            {
                current.Value.Action();
                pendingConditionalActions.Remove(current);
            }
        }
    }
    public void RegisterConditionalAction(ConditionalAction action)
    {
        pendingConditionalActions.AddLast(action);
    }
