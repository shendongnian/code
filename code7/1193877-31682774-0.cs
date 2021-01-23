    // using System.Text.RegularExpressions;
    string[] searchTerms = new[] { "Close", "Enter", "Leave" };
    // if the richtextbox is not empty; highlight the search criteria
    if (richTextBox1.Text != string.Empty)
    {
        // reset the selection
        string text = richTextBox1.Text;
        richTextBox1.Text = "";
        richTextBox1.Text = text;
        // find all matches
        foreach (Match m in new Regex(string.Join("|", searchTerms.Select(t => t.Replace("|", "\\|")))).Matches(richTextBox1.Text))
        {
            // for each match, select and then set the color
            richTextBox1.Select(m.Index, m.Length);
            richTextBox1.SelectionColor = Color.Cyan;
        }
    }
