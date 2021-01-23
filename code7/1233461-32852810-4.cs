    public static class StrategicStatesExtension
    {
        public static Status[] Created
        {
            get
            {
                return new [] { Status.Created, Status.Dispatched };
            }
        }
        public static Status[] Dispatched
        {
            get
            {
                return new [] { Status.Delayed, Status.Delivered, Status.Dispatched };
            }
        }
        public static Status[] Delayed
        {
            get
            {
                return new [] { Status.Delivered, Status.Dispatched, Status.Delayed };
            }
        }
        public static Status[] GetAssociatedValidStatus(this Status currentStatus)
        {
            switch (currentStatus)
            {
                case Status.Created:
                    return Created;
                case Status.Dispatched:
                    return Dispatched;
                case Status.Delayed:
                    return Delayed;
                case Status.Delivered:
                    return Status.Delivered;
                default:
                    throw new ArgumentOutOfRangeException("Invalid current state received.");
            }
        }
        public static List<SelectListItem> ToDropDownList(this Status[] sourceStates)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in sourceStates)
            {
                items.Add(
                    new SelectListItem { 
                            Value = item.ToString("d"), // Value of enum (short)
                            Text = item.ToString() // Name of enum
                    });
            }
            return items;
        }
