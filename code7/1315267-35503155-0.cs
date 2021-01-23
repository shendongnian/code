    public partial class MyOrderControl : UserControl
    {
        public MyOrderControl()
        {
            InitializeComponent();
        }
    
        public class Order
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    
        public Order GetFilledOrder()
        {
            //Validate data
            return new Order()
            {
                Name = textBox1.Text,
                Quantity = (int)numericUpDown1.Value
            };
        }
    }
