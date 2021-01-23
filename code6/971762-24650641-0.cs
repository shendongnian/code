    public class MyProject
        {
            public MyProject()
            {
              this.MyProjectId =string.Empty;
              this.ProjectId =string.Empty;
              this.ContactId =string.Empty;
            }
            public string MyProjectId { get; set; }
            public string ProjectId { get; set; }
            public string ContactId { get; set; }
            public int DisplayOrder { get; set; }
        }
        
        public class RootObject
        {
    
            public RootObject()
            {
              this.MyProject =new MyProject ();
            }
    
            public string UserToken { get; set; }
            public MyProject MyProject { get; set; }
        }
