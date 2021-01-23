    string text = "";
    foreach (string val in values) {
       // where val is matching your variable.Name use variable.Value instead
       // else is white space or other... just add to text var.
       if (val.Equals(variable.Name)) {
           text += variable.Value;
       } else {
           text += val;
       }
    }
    MessageBox.Show(text);
