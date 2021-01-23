    public class Organization : TableEntity
    {
        public String OrganizationGroupId
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }
        public String Id
        {
            get { return this.RowKey; }
            set { this.RowKey = value; }
        }
    }
