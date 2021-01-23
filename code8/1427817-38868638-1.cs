    public class Login
    {
       public int Id { get; set; } //foreign key declaration
       public int TeamMemberId { get; set; }
       public  TeamMember TeamMember { get; set; }
    }
    public class TeamMember
    {
       public int TeamMemberId { get; set; }
       public Ilist<Login> Login { get; set; }
    }
