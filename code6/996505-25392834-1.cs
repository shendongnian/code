        public class OrderEntity:EntityBase
    {
        [Required(ErrorMessage="Name is Required")]
        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }
        [Required(ErrorMessage = "OrderNumber is Required")]
        public string OrderNumber
        {
            get { return GetValue(() => OrderNumber); }
            set { SetValue(() => OrderNumber, value); }
        }
        [Required(ErrorMessage = "Quantity is Required")]
        [Range(20,75,ErrorMessage="Quantity must be between 20 and 75")]
        public int Quantity
        {
            get { return GetValue(() => Quantity); }
            set { SetValue(() => Quantity, value); }
        }
        public short Status { get; set; }
    }
