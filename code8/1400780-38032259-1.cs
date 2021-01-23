    public class Skill2
    {
        public string SkillID { get; set; }
        public string ParticipantID { get; set; }
        public string CanDo { get; set; }
    }
    public class Skill
    {
        public List<Skill2> Skill { get; set; }
    }
    public class CommunicationMessage
    {
        public List<Skill> Skills { get; set; }
    }
