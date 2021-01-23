    public DateTime Value {
                set {
                    bool valueChanged = !DateTime.Equals(this.Value, value);
                    // Check for value set here; if we've not set the value yet, it'll be Now, so the second
                    // part of the test will fail.
                    // So, if userHasSetValue isn't set, we don't care if the value is still the same - and we'll
                    // update anyway.
                    if (!userHasSetValue || valueChanged) {
                        if ((value < MinDate) || (value > MaxDate)) {
                            throw new ArgumentOutOfRangeException("Value", SR.GetString(SR.InvalidBoundArgument, "Value", FormatDateTime(value), "'MinDate'", "'MaxDate'"));
                        }
    }
