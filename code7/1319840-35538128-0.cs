    public static List<AssignmentHistory> assignmentHistList
    {
        get { return GetAssignmentHistoryList(); }
    }
    
    public static List<AssignmentHistory> GetAssignmentHistoryList()
    {
        if (!System.IO.File.Exists(ASSIGNMENT_HISTORY_FILENAME)) return null;
        if (null == assignmentHistList) << Here is another call to the Getter
        // The rest is not important
    }
