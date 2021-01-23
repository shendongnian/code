     [Serialiazable]
     Public class OrganizationUnit
     {
        public int ID {get; set;}
        public IEnumerable<WorkFile> WorkFiles {set; get}
     }
     [Serialiazable]
     Public class WorkFile
     {
        public int ID {get;set;}
        [NonSerialized]
        public OrganizationUnit ParentOrgUnit {set; get;}
        public IEnumerable<WorkItem> WorkItems{set; get}
     }
     [Serialiazable]
     Public class WorkItem
     {
        public int ID {get; set;}
        [NonSerialized]
        public WorkFile ParentWorkFile {set; get;}
        
     }
