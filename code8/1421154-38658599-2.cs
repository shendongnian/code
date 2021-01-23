    private void assignmentfinder(string brief, string id)
    {
        string searchcrit = "ASSIGNMENT";
        string assignment = brief.Substring(brief.IndexOf(searchcrit) + searchcrit.Length);
        
        string[] assignmentSplit = assignment.Split('\n'); // splitting at new line
        richTextBox1.Lines = assignmentSplit;
        listBox2.DataSource = assignmentSplit.ToList();
    }
