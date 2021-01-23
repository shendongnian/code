    public void bindListener(int actionID, List<string> actionArgs, int listenerID)
    {
        boundActions[actionID][actionArgs] = new Action(delegate { actions.getAction(actionID, actionArgs).Invoke(); });
        listenerMap[listenerID] += new EventListener(boundActions[actionID][actionArgs]);
    }
    public void unbindListener(int actionID, List<string> actionArgs, int listenerID)
    {
        listenerMap[listenerID] -= new EventListener(boundActions[actionID][actionArgs]);
    }
