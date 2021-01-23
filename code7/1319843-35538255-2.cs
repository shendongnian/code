    // this is the backing field for your property
    private static List<AssignmentHistory> assignmentHistList;
    // it is good practice to name properties starting uppercase
    public static List<AssignmentHistory> AssignmentHistList
    {
        get 
        {
            // return the content of the backing field if is not null
            return assignmentHistList ??
                // in case the backing field is null,
                // assign it a value from your deserialize method
                // and than return it
                (assignmentHistList = DeserializeAssignmentHistFile());
        }
    }
    
    private static List<AssignmentHistory> DeserializeAssignmentHistFile()
    {
        // If the file which should contain your data does not exist (yet) return null,
        // the property will retry to set the backing field the next time it is accessed
        if (!System.IO.File.Exists(ASSIGNMENT_HISTORY_FILENAME)) return null;
        var assignmentHistFile 
            = System.IO.File.ReadAllText(ASSIGNMENT_HISTORY_FILENAME);
        var assignmentHistDeserialized 
            = JsonConvert.DeserializeObject<List<AssignmentHistory>>(assignmentHist);
        return assignmentHistDeserialized;
    }
