    public partial class Organization
    {
        public int OrganizationId { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public OrganizationSettings Settings { get; set; }
    }
    public class OrganizationSettings
    {
        public bool AllowMultipleTimers { get; set; }
    }
