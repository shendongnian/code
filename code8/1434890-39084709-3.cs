    [Serializable]
    public class Student
    {
        [JsonProperty("fname")]
        public string FirstName{ get; set; }
        [JsonProperty("lname")]
        public string LastName{ get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("grade")]
        public string Grade { get; set; }
    }
    
    [Serializable]
    public class NewModel
    {
        public Student Student { get; set; }
    }
