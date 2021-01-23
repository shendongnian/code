    public class Friend
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public override string ToString()
        {
            return String.Format("User: Id={0}; UserId={1}", Id, UserId);
        }
    }
