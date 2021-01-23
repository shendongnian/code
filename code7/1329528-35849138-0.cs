      class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                Temp ch = new Temp();
                ch.SetParamValue("test", "test", db);
                ch.GetParamValue("test",db);
            }
        }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Param> Params { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
    }
    public class Param
    {
        public long ParamID { get; set; }
        public virtual ChatUser ChatUser { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class ChatUser
    {
        public int ChatUserID { get; set; }
        public virtual ICollection<Param> Params { get; set; }
      
    }
    public class Temp
    {
        public string GetParamValue(string paramName, ApplicationDbContext db)
        {
            return db.Params.FirstOrDefault(p => p.Name == paramName && p.ChatUser.ChatUserID == 1).Value;
        }
        public void SetParamValue(string paramName, string paramVal, ApplicationDbContext db)
        {
            var result = db.Params.FirstOrDefault(p => p.Name == paramName && p.ChatUser.ChatUserID == 1);
            if (result == null)
                db.Params.Add(new Param { Name = paramName, Value = paramVal, ChatUser = new ChatUser {ChatUserID=1 } });
            else
                result.Value = paramVal;
            db.SaveChanges();
        }
    }
