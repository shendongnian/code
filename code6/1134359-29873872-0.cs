    public partial class Form1 : Form
    {
        List<Product> source;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            source = new List<Product>();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var existingProduct = source.Where(x=> x.ProductName==txtProduct.Text).SingleOrDefault();
            if(existingProduct!=null)
            {
                existingProduct.Price += decimal.Parse(txtPrice.Text); 
            }
            else
                source.Add(new Product {Price = decimal.Parse(txtPrice.Text.ToString()), ProductName = txtProduct.Text} );
            listBox1.DataSource = null;
            listBox1.DataSource = source;
        }
     }
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return string.Format("{0} = {1}", ProductName, Price.ToString("c"));
        }
    }
