    public class SenderId
    {
        public int Id { get; set; }
        public string DisplayMember {get; set;}
        // this is how it will display the items:
        public override string ToString()
            {
                return $"{DisplayMember} [{Id}]";
            }
    }
