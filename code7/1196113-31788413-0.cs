    public class OrganizationUnitTreeViewModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public List<OrganizationUnitTreeViewModel> Items { get; set; }
        public bool Expanded = true;
        public bool LoadOnDemand = true;
    }
