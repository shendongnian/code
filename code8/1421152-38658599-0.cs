    private void assignmentfinder(string brief, string id)
    {
        string searchcrit = "ASSIGNMENT";
        string assignment = brief.Substring(brief.IndexOf(searchcrit) + searchcrit.Length);
        
        string[] assignmentSplit = assignment.Split('\n');
        richTextBox1.Lines  = assignmentSplit; // splitting at new line
        listBox2.DataSource = assignmentSplit.ToList();
    }
