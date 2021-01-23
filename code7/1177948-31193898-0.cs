    [Serializable]
    public struct User
    {
        public string Name;
        //this should never be persisted
        [NonSerialized]
        public string Password;
    }
    //when I persist this, it persists the CreatedBy User without the password
    [Serializable]
    public class Record
    {
        //password won't be persisted now
        public User CreatedBy{ get; set; }
        //other information I want to save
    }
