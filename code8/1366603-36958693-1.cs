    string someString = "Blah blah blah";
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    foreach(char c in someString) {
        if (!Char.IsWhiteSpace(c)) {
            sb.Append(c);
        }
    }
    someString = sb.ToString();
