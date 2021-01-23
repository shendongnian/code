    public class MailBoxInfo
    {
        [BsonId]
        public int Id { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Last { get; set; }
        public override string ToString()
        {
            return string.Format("Id : {0}, Updated : {1}, Last Message : {2}",
                Id,
                Updated,
                Last);
        }
    }
