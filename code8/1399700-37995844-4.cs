    internal class MroViewModel : IStatusViewModel {
            public int StatusId { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedDate { get; set; }
    }
