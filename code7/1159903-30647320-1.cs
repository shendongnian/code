    public class User
    {
        public Guid UserId { get; set; }
    }
    public class Member
    {
        public Guid ClubId { get; set; }
        public Guid UserId { get; set; }
    }
    public class Club
    {
        public Guid ClubId { get; set; }
        public Member RegisterMember(User user)
        {
            // Check business rules..
            return new Member { UserId = user.Id, ClubId = this.ClubId };
        }
    }
