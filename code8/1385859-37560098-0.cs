    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<CartItem> cartItems = new List<CartItem>();
                cartItems.Add(new CartItem
                {
                    ItemNumber = "1234",
                    Description = "Small widget",
                    Quantity = 2,
                    Price = 1.50,         
                });
                cartItems.Add(new CartItem
                {
                    ItemNumber = "6789",
                    Description = "Large widget",
                    Quantity = 1,
                    Price = 10.00,
                });
                double total = 0;
                foreach(CartItem item in cartItems)
                {
                    total += item.ExtendedPrice;
                }
                MessageBox.Show("Your total is $" + total.ToString());
            }
        }
        public class CartItem
        {
            public CartItem(){}
            public string ItemNumber { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public double ExtendedPrice { get { return Price * Quantity; } }
        }   
    }
