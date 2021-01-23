    string text = "";
    foreach (string val in values) {
       // where val is matching your variable (let's assume you are using dictionary for storing the values)
       // else is white space or other... just add to text var.
       if (yourDictionary.ContainsKey(val)) {
           text += yourDictionary[val];
       } else {
           text += val;
       }
    }
    MessageBox.Show(text);
