    public class UspGetSideBarListReturnDto
    {
        public List<Set1ReturnDto> Dummy1 { get; set; }
        public List<Set2ReturnDto> Dummy2 { get; set; }
    }
    public class Set1ReturnDto
    {
        public Int32 CruiseCount { get; set; }
        public string DisplayText { get; set; }
        public Int64 DisplayValue { get; set; }
    }
    public class Set2ReturnDto
    {
        public string DepartingFrom { get; set; }
        public string Port_Code { get; set; }
    }
