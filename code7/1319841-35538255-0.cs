    private static List<AssignmentHistory> assignmentHistList;
    public static List<AssignmentHistory> AssignmentHistList
    {
        get 
        {
            return assignmentHistList
                ?? (assignmentHistList = DeserializeAssignmentHistFile());
        }
    }
    
    private static List<AssignmentHistory> DeserializeAssignmentHistFile()
    {
        if (!System.IO.File.Exists(ASSIGNMENT_HISTORY_FILENAME)) return null;
        var assignmentHistFile 
            = System.IO.File.ReadAllText(ASSIGNMENT_HISTORY_FILENAME);
        var assignmentHistDeserialized 
            = JsonConvert.DeserializeObject<List<AssignmentHistory>>(assignmentHist);
        return assignmentHistDeserialized;
    }
