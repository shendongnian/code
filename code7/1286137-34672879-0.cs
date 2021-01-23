    [SQLite.Table("DBComment")]
    public class DBCommentLite
    {
        public DBCommentLite(DBModel.DBUser user, DBModel.DBComment comment)
        {
            DBUser_id = user.Id;
            CommentId = comment.CommentId;
        }
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int Id { get; set; }
        public long CommentId { get; set; }
        public long DBUser_id { get; set; }
    }
