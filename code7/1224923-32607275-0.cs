        public class Project : IModel
        {
            //Internal DB Id
            [DataMember]
            public int ProjectID { get; set; }
            //Project No - Auto Generated at service level
            [DataMember]
            public string ProjectNo { get; set; }
            public ProjectExtra ProjectExtra { get; set; }
        }
        public class ProjectExtra : IModel
        {
            [DataMember]
            public int ProjectID { get; set; }
            [DataMember]
            public string Description { get; set; }
            public Project Project { get; set; }
        }
