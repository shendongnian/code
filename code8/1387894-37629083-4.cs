    public class UserType
    {
        public float Time { get; set; }
    }
    public class UserInitAndModify : IInitAndModify<UserType>
    {
        public UserType CreateNew()
        {
            return new UserType { Time = 0 };
        }
        public void Modify(UserType item)
        {
            item.Time++;
        }
    }
