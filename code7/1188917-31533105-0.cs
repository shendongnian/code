        public class Issuetype
        {
            public string self { get; set; }
            public string id { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public bool subtask { get; set; }
        }
    
        public class AvatarUrls
        {
            public string __invalid_name__48x48 { get; set; }
            public string __invalid_name__24x24 { get; set; }
            public string __invalid_name__16x16 { get; set; }
            public string __invalid_name__32x32 { get; set; }
        }
    
        public class Project
        {
            public string self { get; set; }
            public string id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public AvatarUrls avatarUrls { get; set; }
        }
    
        public class AvatarUrls2
        {
            public string __invalid_name__48x48 { get; set; }
            public string __invalid_name__24x24 { get; set; }
            public string __invalid_name__16x16 { get; set; }
            public string __invalid_name__32x32 { get; set; }
        }
    
        public class Reporter
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            public AvatarUrls2 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
        }
    
        public class Priority
        {
            public string self { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }
    
        public class AvatarUrls3
        {
            public string __invalid_name__48x48 { get; set; }
            public string __invalid_name__24x24 { get; set; }
            public string __invalid_name__16x16 { get; set; }
            public string __invalid_name__32x32 { get; set; }
        }
    
        public class Author
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            public AvatarUrls3 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
        }
    
        public class AvatarUrls4
        {
            public string __invalid_name__48x48 { get; set; }
            public string __invalid_name__24x24 { get; set; }
            public string __invalid_name__16x16 { get; set; }
            public string __invalid_name__32x32 { get; set; }
        }
    
        public class UpdateAuthor
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            public AvatarUrls4 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
        }
    
        public class Comment2
        {
            public string self { get; set; }
            public string id { get; set; }
            public Author author { get; set; }
            public string body { get; set; }
            public UpdateAuthor updateAuthor { get; set; }
            public string created { get; set; }
            public string updated { get; set; }
        }
    
        public class Comment
        {
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<Comment2> comments { get; set; }
        }
    
        public class Votes
        {
            public string self { get; set; }
            public int votes { get; set; }
            public bool hasVoted { get; set; }
        }
    
        public class AvatarUrls5
        {
            public string __invalid_name__48x48 { get; set; }
            public string __invalid_name__24x24 { get; set; }
            public string __invalid_name__16x16 { get; set; }
            public string __invalid_name__32x32 { get; set; }
        }
    
        public class Assignee
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            public AvatarUrls5 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }
        }
    
        public class StatusCategory
        {
            public string self { get; set; }
            public int id { get; set; }
            public string key { get; set; }
            public string colorName { get; set; }
            public string name { get; set; }
        }
    
        public class Status
        {
            public string self { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public StatusCategory statusCategory { get; set; }
        }
    
        public class Fields
        {
            public string summary { get; set; }
            public Issuetype issuetype { get; set; }
            public List<object> components { get; set; }
            public string created { get; set; }
            public string description { get; set; }
            public Project project { get; set; }
            public Reporter reporter { get; set; }
            public Priority priority { get; set; }
            public object resolution { get; set; }
            public string duedate { get; set; }
            public Comment comment { get; set; }
            public Votes votes { get; set; }
            public Assignee assignee { get; set; }
            public Status status { get; set; }
        }
    
        public class Issue
        {
            public string expand { get; set; }
            public string id { get; set; }
            public string self { get; set; }
            public string key { get; set; }
            public Fields fields { get; set; }
        }
    
        public class RootObject
        {
            public string expand { get; set; }
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<Issue> issues { get; set; }
        }
    
    var t = JsonConvert.DeserializeObject<RootObject>(json);
    var issues = t.issues;
