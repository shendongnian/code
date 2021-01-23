    var group1 = new[] { a, b, c };
    var group2 = new[] { d, f };
    // assuming all controls are the same or implement the same interface
    Func<ControlType, bool> isEnabledAndHasValue = (x) => {
        return x.IsEnabled && !String.IsNullOrWhitespace(x.Text);
    };
    var ok = group1.Any(isEnabledAndHasValue) && group2.Any(isEnabledAndHasValue);
