    private void UpdateStates(bool useTransitions)
    {
       if (IsState1)
       {
           VisualStateManager.GoToState(this, "State1", useTransitions);
       }
       else if (IsState2)
       {
           VisualStateManager.GoToState(this, "State2", useTransitions);
       }
    }
