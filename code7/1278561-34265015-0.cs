    public class OrganizationGroup : TableEntity
    {
        public OrganizationGroup()
        {
            this.RowKey = string.Empty;
        }
        public String Id
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }
    }
