    public class DeliveryVM
    {
        public int? ID { get; set; }
        public Status Status { get; set; }
        public List<SelectListItem> States { get; set; }
        public DeliveryVM()
        {
            // Sample usage: only for demo you need to call this in other method
            // e.g. where your model is being filled with data.
            this.States = Status.GetAssociatedValidStatus().ToDropDownList();    
        }
    }
