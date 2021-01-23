        //User Table
        public class UserDetail //It has both Employee and Manager Records
        {
            public long UserID { get; set; } //Identity Column having both Emp/Manager
            public string Name { get; set; }
            public virtual List<UserOfficialDetail> UserOfficialDetails{ get;set; } //virtual property 
        }
        
    //User Official Detail Table
    public class UserOfficialDetail //It has Employee to Manager assignment
    {
        public long UserOfficialID { get; set; } //Identity Column
        public long ReportingTo { get; set; } //This column will store Manager Id
        public long UserID { get; set; } //Foreign Key to above table
        public virtual List<UserProfiles> UserProfiles { get;set; } //virtual property
    }
