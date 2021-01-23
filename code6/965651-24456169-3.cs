    private State _currentState;
    public State CurrentState {
        set {
            // ...
            // This is for illustration purposes. Normally you'd be checking 
            // or assigning the value of the "value" parameter, not always 
            // setting the same value as this suggests.
            _currentState = state.Whatever;
            // ...
        }
        get {
            return _currentState;
        }
    }
