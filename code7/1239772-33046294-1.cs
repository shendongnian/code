    public static Dictionary<int, Dictionary<List<string>, EventListener>> boundActions;
    public delegate void EventListener();
    public Dictionary<int, EventListener> listenerMap;
    public void bindListener(int actionID, List<string> actionArgs, int listenerID)
    {
        boundActions[actionID][actionArgs] = new EventListener(delegate { actions.getAction(actionID, actionArgs).Invoke(); });
        listenerMap[listenerID] += boundActions[actionID][actionArgs];
    }
    public void unbindListener(int actionID, List<string> actionArgs, int listenerID)
    {
        listenerMap[listenerID] -= boundActions[actionID][actionArgs];
    }
