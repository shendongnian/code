    public class AssignmentHistory
    {
       	public DateTime WeekOfAssignment { get; set; }
        public int TalkType { get; set; } 
      	public int StudentID_FK { get; set; }
        public int AssistantID_FK { get; set; }
       	public int CounselPoint { get; set; }
        public bool HasBeenEmailed { get; set; }
       	public bool SlipHasBeenPrinted { get; set; }        
    }
    
    public static string ASSIGNMENT_TYPES_FILENAME = @"C:\AYttFMApp\AYttFMScheduler\AssignmentTypes.json";
    . . .
    public static List<AssignmentHistory> AssignmentHistList;
    . . .
    public static void SerializeAssignmentHistFile(string fileStorageLoc) 
    {
        var jsonAssignmentHist = JsonConvert.SerializeObject(AssignmentHistList); //_assignmentHistList);
            System.IO.File.WriteAllText(fileStorageLoc, jsonAssignmentHist);
    }
    
    public static List<AssignmentHistory> DeserializeAssignmentHistFile()
    {
        if (!System.IO.File.Exists(ASSIGNMENT_HISTORY_FILENAME))
        {
            var assignmentFile = 
    System.IO.File.Create(ASSIGNMENT_HISTORY_FILENAME);
            assignmentFile.Close();
            return null;
        }
    
        var assignmentHistFile = 
    System.IO.File.ReadAllText(ASSIGNMENT_HISTORY_FILENAME);
        var assignmentHistDeserialized = 
    JsonConvert.DeserializeObject<List<AssignmentHistory>>(assignmentHistFile);
    
        if (null != assignmentHistDeserialized) return 
    assignmentHistDeserialized;
    
        var assignmentHistoryList = new List<AssignmentHistory>();
        return assignmentHistoryList;
    }
