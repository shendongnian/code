    public class CompanyJobPost : IJobPost
    {
        public string CompanyJobPostId { get; set; }
        public string CompanyId { get; set; }
        public string KeySkils { get; set; }
        public string JobDiscription { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class OrganizationJobPost : IJobPost
    {
        public string OrganizationJobPostId { get; set; }
        public string OrganizationId { get; set; }
        public string KeySkils { get; set; }
        public string JobDiscription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ExtraField2 { get; set; }
    }
    public class InstituteJobPost : IJobPost
    {
        public string InstituteJobPostId { get; set; }
        public string InstituteId { get; set; }
        public string KeySkils { get; set; }
        public string JobDiscription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ExtraField { get; set; }
    }
