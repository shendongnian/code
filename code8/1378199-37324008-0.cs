    // let's use regular expression to validate name; 
    // String.StartsWith is also a good choice
    using System.Text.RegularExpressions;
    ...
    // while removing, loop backward
    for (int i = Controls.Count - 1; i >= 0; --i) {
      Label label = Controls[i] as Label;
    
      // Control is Label with specific name
      if ((label != null) && Regex.IsMatch(label.Text, "^dynaLabel_[0-9]+$")) {
        Controls.RemoveAt(i);
    
        // do not forget to release resources allocated (here is HWND - window handle)
        label.Dispose();
      }
    }
