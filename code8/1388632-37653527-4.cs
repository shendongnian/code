    private void txtProjects_Clicked(object sender, EventArgs e)
    {
        int cursorPos = txtProjects.SelectionStart;
        int lineCount = txtProjects.GetLineFromCharIndex(cursorPos) + 1; // zero based
        List<string> lines = txtProjects.Lines.ToList();
        lines.Insert(lineCount, null);
        txtProjects.Lines = lines.ToArray();
        txtProjects.Select(cursorPos, 0);
    }
