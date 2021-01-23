    // Get the assignments
    IList<Assignment> assignments = GetTheListOfAssignments();
    
    // Update labels
    foreach (var assignment in assignments)
    {
        // no error checking here whatsoever
        var label = assignmentToLabelMap[assignment.Name];
        
        if (assignment.IsOverdue)
            label.Text = xxx;
        else
            label.Text = yyy;
    }
