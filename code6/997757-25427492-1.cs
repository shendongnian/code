    var group1 = new[] { a, b, c };
    var group2 = new[] { d, e };
    var all = group1.Concat(group2);
    // assuming all controls are the same or implement the same interface
    Func<ControlType, bool> enabledAndNotEmpty = (x) => {
        return x.IsEnabled && !String.IsNullOrWhiteSpace(x.Text);
    };
    Func<ControlType, bool> enabledAndEmpty = (x) => {
        return x.IsEnabled && String.IsNullOrWhiteSpace(x.Text);
    };
    var ok = group1.Any(enabledAndNotEmpty) && // a, b or c is enabled & not empty
             group2.Any(enabledAndNotEmpty) && // d or e is enabled & not empty
             !all.Any(enabledAndEmpty); // none of the above are enabled & empty
