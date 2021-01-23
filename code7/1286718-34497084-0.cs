    private Action<Employee, Shift, QualCheckState> qualificationCheckCallback;
    public class QualCheckState { public bool Passed { get; set; } }
    // Call it thus:
    var state = new QualCheckState { Passed = true }; // Hope for the best
    qualificationCheckCallback(someEmployee, someShift, state);
    if (state.Passed) {
        // Assume everyone passed
    }
