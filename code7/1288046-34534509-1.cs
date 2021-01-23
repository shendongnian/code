    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            MyModel.NewOrder();
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.Name = "PS4";
            product.Price = 1000000000.0m;
            MyModel.Order.AddProduct(product);
        }
        private void buttonShowProductsInOrder_Click(object sender, EventArgs e)
        {
            var order = MyModel.Order;
            var products = order.Products;
            var builder = new StringBuilder();
            foreach (var product in products)
            {
                var format = string.Format("Name: {0}, Price: {1}", product.Name, product.Price);
                builder.AppendLine(format);
            }
            MessageBox.Show(builder.ToString());
        }
    }
