    public static string GetAssignmentMessage(this DateTime programming, string assignment, int daysRemaining)
    {
    if (DateTime.Now >= programming)
    {
        return "Due date for Programming Assignment " + assignment + " has been reached (" + programming.ToShortDateString() + ").";
    }
    else
    {
        return "Days remaining until Programming Assignment " + assignment + " deadline: " + daysRemaining.ToString("0");
    }
    }
