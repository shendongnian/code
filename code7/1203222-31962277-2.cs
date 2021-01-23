    public class ExecutionViewModel
    {
        public int Id { get; set; }
        public Int16 PackageId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Boolean Successful { get; set; }
        public virtual PagedList.IPagedList<Step> Steps { get; set; }
    }
