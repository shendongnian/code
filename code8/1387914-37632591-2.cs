    public class FriendLoader
    {
        public Friend LoadFriend(string jsonSource)
        {
            return String.IsNullOrEmpty(jsonSource) ? null : JsonConvert.DeserializeObject<Friend>(jsonSource);
        }
        public List<Friend> LoadFriends(string jsonSource)
        {
            var friends = new List<Friend>();
            if (!String.IsNullOrEmpty(jsonSource))
            {
                friends = JsonConvert.DeserializeObject<List<Friend>>(jsonSource);
            }
            return friends;
        }
    }
