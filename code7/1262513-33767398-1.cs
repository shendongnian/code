    namespace MyNamespace
    {
        public class Actor
        {
            public string[] name { get; set; }
            public string[] mbox { get; set; }
    
            public string Name { get { return name[0]; } }
            public string EmailAddress { get { return mbox[0].Replace("mailto:", ""); } }
        }
    }
