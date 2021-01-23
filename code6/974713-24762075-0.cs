    public class JobModel : DynamicModel, IHierarchy
    {
        public string Description { get; set; }
        public DynamicModel Parent { get; set; }
    
        public override string MappedType 
        {
            get
            {
                return "Telerik.Sitefinity.DynamicTypes.Model.Applications.Job";
            }
        }
    
        public JobModel()
            : base()
        {
        }
    
        public JobModel(DynamicContent sfContent)
            : base(sfContent)
        {
            if (sfContent != null)
            {
                Description = sfContent.GetStringSafe("Description");
                Parent = new CareerModel(sfContent.SystemParentItem);
            }
        }
    }
