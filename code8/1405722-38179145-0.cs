    _stateMachine.OnTransitioned(OnTransitionedAction);
    void OnTransitionedAction(StateMachine<StateEnum, TriggerEnum>.Transition transition) {
        TriggerEnum trigger = transition.Trigger;
        StateEnum source = transition.Source;
        StateEnum dest = transition.Destination;
        // log trigger, source, destination
    }
