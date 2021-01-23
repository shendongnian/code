    class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User user1, User user2)
        {
            return user1.Id == user2.Id;
        }
        public int GetHashCode(User user)
        {
            return user.Id;
        }
    }
