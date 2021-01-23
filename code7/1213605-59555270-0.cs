    public IEnumerator LoopAction(Func<IEnumerator> stateAction)
    {
        while(true)
        {
            yield return stateAction.Invoke();
        }
    }
    
    public Coroutine PlayAction(Func<IEnumerator> stateAction, bool loop = false)
    {
        Coroutine action;
        if(loop)
        {
            //If want to loop, pass function call
            action = StartCoroutine(LoopAction(stateAction));
        }
        else
        {
            //if want to call normally, get IEnumerator from function
            action = StartCoroutine(stateAction.Invoke());
        }
    
        return action;
    }
