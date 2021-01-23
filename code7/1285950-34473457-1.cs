    var actions =
       Controls
       .GetValues() // needed since you've shown that Controls is an enum type
       .Select(control => new {
          value = control,
          c = (int)control,
          t = control.ToString()
       }).ToList();
    if (actions.Any(a => a.value == Enums.Controls.Save))
       actions.Remove(Enums.Controls.Submit); // won't work
