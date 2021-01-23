    var t = this.GetType();
    var fields = t.GetFields(BindingFlags.NonPublic |
                         BindingFlags.Instance);
    //assuming you are doing this in a xaml.cs, if not you may need to change
    // the above to GetProperties or use Public flag, depending on how your buttons
    // are defined.
    foreach (var f in fields)
    {
        if (f.FieldType == typeof (Button))
            _buttons.Add(f.GetValue(this));
    }
