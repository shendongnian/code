    public class DTOStudentList
    {
        [JsonProperty("Address")]
        public string Address { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("CourseName")]
        public string CourseName { get; set; }
        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("StudentId")]
        public int StudentId { get; set; }
        [JsonProperty("StudentName")]
        public string StudentName { get; set; }
        [JsonProperty("TelePhoneNumber")]
        public string TelePhoneNumber { get; set; }
    }
    public class Response
    {
        [JsonProperty("DTOStudentList")]
        public IList<DTOStudentList> DTOStudentList { get; set; }
        [JsonProperty("ResponseStatus")]
        public int ResponseStatus { get; set; }
    }
    public class GetStudentsListJSONResult
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("GetStudentsListJSONResult")]
        public GetStudentsListJSONResult GetStudentsListJSONResult { get; set; }
    }
