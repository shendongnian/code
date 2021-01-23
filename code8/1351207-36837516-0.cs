        public class Student
        {
            public int ID { get; set; }
            public int ParentID { get; set; }
            public string Title { get; set; }
        }
        public class Parent
        {
            public int pID { get; set; }
            public int pParentID { get; set; }
            public string pTitle { get; set; }
        }
        public class OutPut
        {
            public int mID { get; set; }
            public int mParentID { get; set; }
            public string mTitle { get; set; }
        }
        public class SubOutPut
        {
           public int SubsmID { get; set; }
            public int SubsmParentID { get; set; }
            public string SubsmTitle { get; set; }
            
        }
