    public class OrganisationCategory
    {
        public int ID { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual Category Category { get; set; }
        public OrganisationCategory() { }
        public OrganisationCategory(Organisation Organisation, Category Category)
        {
            this.Organisation = Organisation;
            this.Category = Category;
        }
    }
