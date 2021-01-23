    public class GetUserResponse
    {
        private List<UserRecord> userRecordList = new List<UserRecord>();
    
        public List<UserRecord> UserRecordList
        {
            get { return userRecordList; }
            set { userRecordList = value; }
        }
    }
