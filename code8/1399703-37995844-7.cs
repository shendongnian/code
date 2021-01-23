    internal interface IStatusViewModel {
            int StatusId { get; set; }
            string Status { get; set; }
            string Description { get; set; }
            bool IsActive { get; set; }
            DateTime CreatedDate { get; set; }
    }
