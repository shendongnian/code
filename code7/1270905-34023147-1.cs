    private float timeToWait = 3f;
    private bool keepExecuting = false;
    private Coroutine executeCR;
    
    public void CallerMethod()
    {
        // If the Coroutine is != null, we will stop it.
        if(executeCR != null)
        {
            StopCoroutine(executeCR);
        }
        // Start Coroutine execution: 
        executeCR = StartCoroutine( ExecuteCR() );
    }
    public void StoperMethod()
    {
        keepExecuting = false;
    }
    private IEnumerator ExecuteCR()
    {
        keepExecuting = true;
        while (keepExecuting)
        {
            // do something
            yield return new WaitForSeconds(timeToWait);
            int rng = UnityEngine.Random.Range(0, 5);
            if (rng >= 0 && rng <= 1)
            {
                oFSM.ChangeStateTo(FSM.States.AtkPatt1);
            }
            else if (rng >= 2 && rng <= 3)
            {
                oFSM.ChangeStateTo(FSM.States.AtkPatt2);
            }
            else if (rng >= 4 && rng <= 5)
            {
                oFSM.ChangeStateTo(FSM.States.AtkPatt3);
            }
        }
        // All Coroutines should "return" (they use "yield") something
        yield return null;    
    }
