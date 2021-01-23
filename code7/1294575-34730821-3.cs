    void AI(..., ref int previous) { ... }
    
    int param;
    AI(..., ref param); //when ref is used, original variable wil be changed.
    PreviousCalls.previousBot1Call = param;
