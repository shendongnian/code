            public class OrderEntity : EntityBaseBase
        {
            string name;
            [Required(ErrorMessage = "Name is Required")]
            public string Name
            {
                get { return name; }
                set { name = value; RaisePropertyChanged("Name"); }
            }
            string orderNumber;
            [Required(ErrorMessage = "OrderNumber is Required")]
            public string OrderNumber
            {
                get { return orderNumber; }
                set { orderNumber = value; RaisePropertyChanged("OrderNumber"); }
            }
            int quantity;
            [Required(ErrorMessage = "Quantity is Required")]
            [Range(20, 75, ErrorMessage = "Quantity must be between 20 and 75")]
            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; RaisePropertyChanged("Quantity"); }
            }
            public short Status { get; set; }
        }
