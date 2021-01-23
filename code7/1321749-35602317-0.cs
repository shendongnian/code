    public class Friend
    {
        public int User_Id;
        [ForeignKey("User_Id")]
        public ApplicationUser User;
        public int Friend_Id;
        [ForeignKey("Friend_Id")]
        public ApplicationUser Friend;
        
        public bool IsApproved;
        public DateTime DateCreated;
    }
